    public class Program
      {
        public static void Main(string[] args)
        {
          try
          {
            var iWebHost = CreateWebHostBuilder(args).Build();
            Log.Information("Application starting");
            iWebHost.Run();
          }
          catch (Exception exception)
          {
            Log.Error(exception.ToString());
          }
          finally
          {
            Log.CloseAndFlush();
          }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseSerilog();
      }
