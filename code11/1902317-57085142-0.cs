    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace Testing
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestAsync().Wait();
            }
    
            static async Task TestAsync()
            {
                var urls = new string[]
                {
                    "https://stackoverflow.com/questions/57084989/null-message-on-httpresponse-content-readasstringasync-result-after-1st-foreac",
                    "https://stackoverflow.com/users/2025711/rogala"
                };
    
                using (var httpClient = new HttpClient())
                {
                    foreach (var url in urls)
                    {
                        using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                        {
                            Console.WriteLine($"Request: {url}".PadLeft(5,'*').PadRight(5, '*'));
                            var response = await httpClient.SendAsync(request)
                                .ConfigureAwait(false);
    
                            if (response.IsSuccessStatusCode)
                            {
                                var body = await response.Content.ReadAsStringAsync()
                                .ConfigureAwait(false);
                                Console.WriteLine($"{body.Length}{Environment.NewLine}");
                            }
                            else
                            {
                                Console.WriteLine($"*Bad request: {response.StatusCode}");
                            }
                            
                        }
                }
                }
    
                Console.ReadKey();
            }
        }
    }
