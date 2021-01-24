    //create cookie container separately            
    //and register it as a singleton to be accesed later
    services.AddSingleton<ICookieContainerAccessor, DefaultCookieContainerAccessor>();
    services.AddHttpClient<TypedClient>()
        .ConfigurePrimaryHttpMessageHandler(sp =>
            new HttpClientHandler {
                //pass the container to the handler
                CookieContainer = sp.GetRequiredService<ICookieContainerAccessor>().CookieContainer
            }
        );
