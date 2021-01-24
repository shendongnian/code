    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();       
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "App crashed");
            }
            finally
            {
                Log.CloseAndFlush();
            }            
        }
    
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(false) //allow startup errors to propagate
                .UseStartup<Startup>();
    }
