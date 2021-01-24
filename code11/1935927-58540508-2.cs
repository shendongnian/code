    services.AddHttpClient<IUsersService, HttpUsersService>(options =>
                {
                    options.BaseAddress = new Uri("https://api.example.com/");
                    options.DefaultRequestHeaders.Accept.Clear();
                    options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                })
                    .ConfigureHttpMessageHandlerBuilder(h =>
                        new HttpClientHandler
                        {
                            DefaultProxyCredentials = CredentialCache.DefaultCredentials,
                        });
