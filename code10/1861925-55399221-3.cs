    public class MyTestServer
        {
            //I add an HttpClient that will be used in the test methods to make the actual call
            internal HttpClient Client { get; set; }
    
    
            public MyTestServer()
            {
                IWebHostBuilder builder = new WebHostBuilder()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        IHostingEnvironment env = hostingContext.HostingEnvironment;
                        config.AddJsonFile("testsettings.json", optional: true)
                            .AddJsonFile($"testsettings.{env.EnvironmentName}.json", optional: true);
                    })
                    .UseStartup<MyTestStartup>();
                builder.UseSetting(WebHostDefaults.ApplicationKey, typeof(Program).GetTypeInfo().Assembly.FullName);
                var testServer = new TestServer(builder);
                Client = testServer.CreateClient();
            }
        }
