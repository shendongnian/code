    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static async Task Main()
            {
                var client = new HttpClient();
                var content = new StringContent("{ \"your\": \"content\", \"maybe\": \"json\" }");
                content.Headers.Add("X-SOME-RANDOM", "header-value");
                var response = await client.PostAsync("https://httpbin.org/post", content);
                
                var httpStatus = response.StatusCode;
                var body = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine($"{httpStatus} {body}");
            }
        }
    }
