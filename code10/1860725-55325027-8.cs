    var host = new HostBuilder()
                    .SetAzureFunctionsEnvironment()
                    .ConfigureLogging(b =>
                    {
                        b.SetMinimumLevel(LogLevel.Information);
                        b.AddConsole();
                    })
                    .AddScriptHost(options, webJobsBuilder =>
                    {
                        webJobsBuilder.AddAzureStorageCoreServices();
                    })
                    .UseConsoleLifetime()
                    .Build();
