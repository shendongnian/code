            var builder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices(services => services.AddSingleton(startup))
                .UseApplicationInsights()
                .UseSetting(WebHostDefaults.ApplicationKey, startup.GetType().Assembly.FullName);
