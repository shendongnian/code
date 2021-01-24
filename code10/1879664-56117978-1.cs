    services.AddHttpClient<MyAutoRestClientExtended>()
                       .ConfigureHttpClient((sp, httpClient) =>
                       {                         
                           httpClient.Timeout = TimeSpan.FromSeconds(30);
                       })
                       .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                       .ConfigurePrimaryHttpMessageHandler(x => new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })
                       .AddHttpMessageHandler(sp => sp.GetService<AuthenticationHandlerFactory>().CreateAuthHandler())
                       .AddPolicyHandlerFromRegistry(PollyPolicyName.HttpRetry)
                       .AddPolicyHandlerFromRegistry(PollyPolicyName.HttpCircuitBreaker);
