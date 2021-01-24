        private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services
                .AddLogging(loggingBuilder =>
                    loggingBuilder.AddSerilog(
                        new LoggerConfiguration()
                            .WriteTo.DatadogLogs(
                                apiKey: "REPLACE - DataDog API Key",
                                host: Environment.MachineName,
                                source: "REPLACE - Log-Source",
                                service: GetServiceName(),
                                configuration: new DatadogConfiguration(),
                                logLevel: LogEventLevel.Infomation
                            )
                            .CreateLogger())
                );
 
            return services;
        }
 
