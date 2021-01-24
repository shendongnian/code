    public class Startup
    {
        private static readonly string url = "https://localhost:44379/ChatHub";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<HubConnection>((serviceProvider) => {
                var hubConnection = new HubConnectionBuilder().WithUrl(url).Build();
                hubConnection.StartAsync().Wait();                
                return hubConnection;
            });           
        }
       
    }
