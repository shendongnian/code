     services.AddAuthentication(options =>
                    {
                        options.DefaultScheme = "Cookies";
                        options.DefaultChallengeScheme = "Google";
                    })
                    .AddCookie("Cookies")
                    .AddGoogleOpenIdConnect("Google", options =>
                    {
                        var clientInfo = (ClientInfo)services.First(x => x.ServiceType == typeof(ClientInfo)).ImplementationInstance;
                        options.ClientId = clientInfo.ClientId;
                        options.ClientSecret = clientInfo.ClientSecret;
                        options.Scope.Add("profile");   
                       
                    });
    
            }
