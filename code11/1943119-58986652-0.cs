    public class Program {
        static Lazy<HttpClient> client = new Lazy<HttpClient>();
        public static async Task Main(string[] args) {
            var host = CreateWebHostBuilder(args).Start();//non blocking start
            using (host) {
                bool started = false;
                do {
                    var response = await client.Value.GetAsync("site root");
                    started = response.IsSuccessStatusCode;
                    await Task.Delay(someDelayHere);
                }) while(!started);
                
                host.WaitForShutdown();
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => {
                    services.AddHostedService<PaymentQueueService>();
                })
                .Configure((IApplicationBuilder app) => {
                    app.UseMvc();
                })
                .UseStartup<Startup>();
    }
