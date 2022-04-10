using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;



//string json = await response.Content.ReadAsStringAsync();
namespace deneme
{
    class Program
    {
         
        
        static string url="https://www.instagram.com/graphql/query/?query_hash=3dec7e2c57367ef3da3d987d89f9dbc8&variables={\"id\"%3A\"22193457691\"%2C\"include_reel\"%3Atrue%2C\"fetch_mutual\"%3Afalse%2C\"first\"%3A24}";

        static string has_nex_page;

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("instgrm başladı");
            List<string> hatersName = new List<string>();
            List<string> hatersID = new List<string>();
            List<string> hatersFollowsme = new List<string>();
            List<string> hatersIfollow = new List<string>();
            do
            {
                Back insta = new();
                var handler = new HttpClientHandler();

                // If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
                handler.AutomaticDecompression = DecompressionMethods.All;

                using (var httpClient = new HttpClient(handler))
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
                    {
                        request.Headers.TryAddWithoutValidation("authority", "www.instagram.com");
                        request.Headers.TryAddWithoutValidation("pragma", "no-cache");
                        request.Headers.TryAddWithoutValidation("cache-control", "no-cache");
                        request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Chromium\";v=\"90\", \"Opera\";v=\"76\", \";Not A Brand\";v=\"99\"");
                        request.Headers.TryAddWithoutValidation("dnt", "1");
                        request.Headers.TryAddWithoutValidation("x-ig-www-claim", "hmac.AR2LPxtWKu4IQ7MzX2xIDqZL4W2I5lk8ceV9ySl0Ql9jhIPK");
                        request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                        request.Headers.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36 OPR/76.0.4017.107");
                        request.Headers.TryAddWithoutValidation("accept", "*/*");
                        request.Headers.TryAddWithoutValidation("x-requested-with", "XMLHttpRequest");
                        request.Headers.TryAddWithoutValidation("x-csrftoken", "0tH7je49zkuqAUzmx1lwZCugW0RVp6Sk");
                        request.Headers.TryAddWithoutValidation("x-ig-app-id", "936619743392459");
                        request.Headers.TryAddWithoutValidation("sec-fetch-site", "same-origin");
                        request.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
                        request.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
                        request.Headers.TryAddWithoutValidation("referer", "https://www.instagram.com/u.unal0/following/");
                        request.Headers.TryAddWithoutValidation("accept-language", "tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7");
                        request.Headers.TryAddWithoutValidation("cookie", "mid=YJzHfwALAAFii0WECeU1ku8ZX7Qc; ig_did=D6639398-C806-46C6-8DF2-6C9C6D50E46C; ig_nrcb=1; fbm_124024574287414=base_domain=.instagram.com; csrftoken=0tH7je49zkuqAUzmx1lwZCugW0RVp6Sk; ds_user_id=22193457691; sessionid=22193457691%3AnBzUrAomg0szSk%3A24; shbid=2755; shbts=1620887435.3394775; rur=FTW; fbsr_124024574287414=ErGt5cEXVSUhi3bJmZBdpy4wOinlOMKh0rDYh_gA6Hw.eyJ1c2VyX2lkIjoiMTAwMDI0NjExMjI5MTgwIiwiY29kZSI6IkFRQzVsYW5qRXotc0tjUHljTDFyWkNKYWxocDdkWWw5N3hJZ1ZJbDl6WjhURlN4V3ZtWUMzS0pRVTgxMVhPUkdvTERWX08tRnlpZ0gzUl9ManJBcVFzbDE2YUQwUlhJcXRBRlJ0allKWEFkWERVLUFMMzFWcnNrdVVSSzVzODItdHhlYlRVMjY1TXozSHlKckZFcnAyM3czMDVZUWctbmxGVllPTzNQVzFydEJrc09GZy1GQ0Nidm5YdFZJR1BnZGZSUWZPUlpYbUUzbXlOOTNXem9OS2FnU21CQmNEX2daclp3aHdycjdzU245MVdfTEdpQy0tbHI0NDBzbHVLR0NNeWJRMFRZaFVBdy1QUm5reTNEd3NPMGw1UFNfZFN3d2RzWjlZV3NJRFJqdm1rNEloWW5JTUR2SW14TVhxREk1bU9ld2JCSHZEVHViemZjQUtWa2c5bWZDIiwib2F1dGhfdG9rZW4iOiJFQUFCd3pMaXhuallCQURrNnNNYkpNQVFORW9CeG5wT2ZNMXVXSHBNN1dBZ3VsOTdZRFBoMFBaQk1IaUQ5bXkxNGhKcllDM2IyaXl0UGdWMUkzVFpDUzJhcHZ3cmZFakUweTV2SmR2OGpGdlJ3QTBSTTZOMkdxNUJvRUJCV0VtRWplVEs1d3RkdmxSeEhZVzd4WTA1TGRUN1NiaGhhU1FFRG9yaHg1a0RSaERsV3g2cHJUWkEiLCJhbGdvcml0aG0iOiJITUFDLVNIQTI1NiIsImlzc3VlZF9hdCI6MTYyMTA2ODQ1NH0; fbsr_124024574287414=ErGt5cEXVSUhi3bJmZBdpy4wOinlOMKh0rDYh_gA6Hw.eyJ1c2VyX2lkIjoiMTAwMDI0NjExMjI5MTgwIiwiY29kZSI6IkFRQzVsYW5qRXotc0tjUHljTDFyWkNKYWxocDdkWWw5N3hJZ1ZJbDl6WjhURlN4V3ZtWUMzS0pRVTgxMVhPUkdvTERWX08tRnlpZ0gzUl9ManJBcVFzbDE2YUQwUlhJcXRBRlJ0allKWEFkWERVLUFMMzFWcnNrdVVSSzVzODItdHhlYlRVMjY1TXozSHlKckZFcnAyM3czMDVZUWctbmxGVllPTzNQVzFydEJrc09GZy1GQ0Nidm5YdFZJR1BnZGZSUWZPUlpYbUUzbXlOOTNXem9OS2FnU21CQmNEX2daclp3aHdycjdzU245MVdfTEdpQy0tbHI0NDBzbHVLR0NNeWJRMFRZaFVBdy1QUm5reTNEd3NPMGw1UFNfZFN3d2RzWjlZV3NJRFJqdm1rNEloWW5JTUR2SW14TVhxREk1bU9ld2JCSHZEVHViemZjQUtWa2c5bWZDIiwib2F1dGhfdG9rZW4iOiJFQUFCd3pMaXhuallCQURrNnNNYkpNQVFORW9CeG5wT2ZNMXVXSHBNN1dBZ3VsOTdZRFBoMFBaQk1IaUQ5bXkxNGhKcllDM2IyaXl0UGdWMUkzVFpDUzJhcHZ3cmZFakUweTV2SmR2OGpGdlJ3QTBSTTZOMkdxNUJvRUJCV0VtRWplVEs1d3RkdmxSeEhZVzd4WTA1TGRUN1NiaGhhU1FFRG9yaHg1a0RSaERsV3g2cHJUWkEiLCJhbGdvcml0aG0iOiJITUFDLVNIQTI1NiIsImlzc3VlZF9hdCI6MTYyMTA2ODQ1NH0");

                        var response = await httpClient.SendAsync(request);
                        string json = await response.Content.ReadAsStringAsync();

                        //var x=insta.PrettyJson(json);
                        JObject details = JObject.Parse(json);
                        //string test = details.First.ToString();
                        // foreach (var i in details.First)
                        // {
                        //     Console.WriteLine(i);
                        // }
                        //var details1 = JObject.Parse(details.First.ToString());
                        JArray ara = JArray.Parse(details.First.First.First.First.First.First.Last.First.ToString());

                       for (int i = 0; i < ara.Count; i++)
                       {
                           if ((string)ara[i].First.First["follows_viewer"] == "False")
                           {
                                hatersID.Add((string)ara[i].First.First["id"]);
                                hatersName.Add((string)ara[i].First.First["username"]);
                                hatersFollowsme.Add((string)ara[i].First.First["follows_viewer"]);
                                hatersIfollow.Add((string)ara[i].First.First["followed_by_viewer"]);
                            }
                       
                       }

                        Console.WriteLine(hatersID.Count + "haters has been spotted");
                        string end_cursor = insta.getBetween(json, "\"end_cursor\":\"", "==\"},");
                        has_nex_page = insta.getBetween(json, "\"has_next_page\":", ",\"e");

                        url = "https://www.instagram.com/graphql/query/?query_hash=3dec7e2c57367ef3da3d987d89f9dbc8&variables=%7B%22id%22%3A%2222193457691%22%2C%22include_reel%22%3Atrue%2C%22fetch_mutual%22%3Afalse%2C%22first%22%3A12%2C%22after%22%3A%22" + end_cursor + "%3D%3D%22%7D";
                    }
                }

            } while (has_nex_page == "true");


            foreach (var i in hatersID)
            {
                var handler1 = new HttpClientHandler();

                // If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
                handler1.AutomaticDecompression = DecompressionMethods.All;

                using (var httpClient1 = new HttpClient(handler1))
                {
                    using (var request1 = new HttpRequestMessage(new HttpMethod("POST"), "https://www.instagram.com/web/friendships/" + i + "/unfollow/"))
                    {
                        request1.Headers.TryAddWithoutValidation("authority", "www.instagram.com");
                        request1.Headers.TryAddWithoutValidation("content-length", "0");
                        request1.Headers.TryAddWithoutValidation("pragma", "no-cache");
                        request1.Headers.TryAddWithoutValidation("cache-control", "no-cache");
                        request1.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Chromium\";v=\"90\", \"Opera\";v=\"76\", \";Not A Brand\";v=\"99\"");
                        request1.Headers.TryAddWithoutValidation("dnt", "1");
                        request1.Headers.TryAddWithoutValidation("x-ig-www-claim", "hmac.AR2LPxtWKu4IQ7MzX2xIDqZL4W2I5lk8ceV9ySl0Ql9jhGxy");
                        request1.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                        request1.Headers.TryAddWithoutValidation("x-instagram-ajax", "0019e974ed32");
                        request1.Headers.TryAddWithoutValidation("accept", "*/*");
                        request1.Headers.TryAddWithoutValidation("x-requested-with", "XMLHttpRequest");
                        request1.Headers.TryAddWithoutValidation("x-asbd-id", "437806");
                        request1.Headers.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 OPR/76.0.4017.154");
                        request1.Headers.TryAddWithoutValidation("x-csrftoken", "8tofVjV0dCtBDfu32faZta4B8tpmiMzs");
                        request1.Headers.TryAddWithoutValidation("x-ig-app-id", "936619743392459");
                        request1.Headers.TryAddWithoutValidation("origin", "https://www.instagram.com");
                        request1.Headers.TryAddWithoutValidation("sec-fetch-site", "same-origin");
                        request1.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
                        request1.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
                        request1.Headers.TryAddWithoutValidation("referer", "https://www.instagram.com/nanajjwheheb/");
                        request1.Headers.TryAddWithoutValidation("accept-language", "tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7");
                        request1.Headers.TryAddWithoutValidation("cookie", "mid=YKvimwALAAElmi2-j-dspyTdCIl4; ig_did=444FE354-AE28-46F4-A0A5-F5E3FA94D879; ig_nrcb=1; fbm_124024574287414=base_domain=.instagram.com; csrftoken=8tofVjV0dCtBDfu32faZta4B8tpmiMzs; ds_user_id=22193457691; sessionid=22193457691%3ABHdWedge4CrgGw%3A22; shbid=2755; rur=FTW; shbts=1622221331.3493338; fbsr_124024574287414=aqtcSd_hgpvHu6VfPxnEhhgVXIYCTcbmoDZsfWzsr4s.eyJ1c2VyX2lkIjoiMTU5MjQ0NDkxNCIsImNvZGUiOiJBUUFvUkFIdng4YnVsNlgxRUZBcUJ6RXF4dVdYcHNXZjduRFZTS2RpRzNUTDkzWEVXemIyRXNXZENKRzVOcUwwc1FkZGdjZXJRYkpIX0pwR0NaczB6c3BtMkJmYVdCMkpqSGthU1FTS0lVdEhwUGpIeEVTWHhtQmluRk9SYTY0TmE3cFQ3WFRPVFZPSnFNeFFPdEN0S0VqT3RPc0dtQUQ1ZHBPaEJuSjJRU21HVmVwZGpqSEhWNVRobE1lQmlScWlqQjlLT0YxbWN0elFKVi1qV3B0XzJUOXR1eF9MR2lQWEtLUC1RRVNxMndBZXlIVk5EejhfS1U5dEVmd1ZwU0NJbmpsb2ZOVnBPZzdQT3pCZW1fejdnYmp3NWZJVUh5NVNxWk5xVndBMUJvSExLX3prV0NKWEhIM01lbEcxVjBwMTNUOCIsIm9hdXRoX3Rva2VuIjoiRUFBQnd6TGl4bmpZQkFGRENJa1pBUEtaQ291bGhjMmVvclJoZEZmT1RwMk5hVUlSUEcwcmhmV1NpRHNCYXl4S3pkbzQxV1NFMWY5VHVFQm5NUmRQWUJEMTNJazdJUWFGOEFoczZDUTQ3bWhuYURLWGhRZE1SOFg3UUxIV3l2MG90bnhZVUtxeDNCME40VXJBTmUwZFhsSE91a2Q5SVhNZVljc1FueFNYbGdhNUU3N0kwbHEiLCJhbGdvcml0aG0iOiJITUFDLVNIQTI1NiIsImlzc3VlZF9hdCI6MTYyMjI5MTk5M30");

                        var response1 = await httpClient1.SendAsync(request1);
                        string json1 = await response1.Content.ReadAsStringAsync();
                        
                        if (json1!= "{\"status\":\"ok\"}")
                        {
                            System.Threading.Thread.Sleep(600000);
                        }
                    }
                }

            }
            
        }
    }
}