    using System;
    using System.Net;
    using System.Net.Http;
    using Google.Apis.Services;
    using Google.Apis.Urlshortener.v1;
    using Google.Apis.Urlshortener.v1.Data;
    using Google.Apis.Http;
    
    namespace ConsoleTestBed
    {
        class Program
        {
            private const string ApiKey = "YourAPIKey";
    
            static void Main(string[] args)
            {
                var initializer = new BaseClientService.Initializer
                {
                    ApiKey = ApiKey,
                    //HttpClientFactory = new ProxySupportedHttpClientFactory()
                };
                var service = new UrlshortenerService(initializer);
                var longUrl = "http://wwww.google.com/";
                var response = service.Url.Insert(new Url { LongUrl = longUrl }).Execute();
    
                Console.WriteLine($"Short URL: {response.Id}");
                Console.ReadKey();
            }
        }
    }
