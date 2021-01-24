    public void ConfigureAuth(IAppBuilder app)
            {
                app.MapAzureSignalR(this.GetType().FullName);
                app.Map("/EnableDetailedErrors", map =>
                {
                    HubConfiguration hubConfiguration = new HubConfiguration
                    {
                        EnableDetailedErrors = true,
                        EnableJavaScriptProxies = false
                    };
                    map.MapAzureSignalR(this.GetType().FullName, hubConfiguration);
                    //map.MapSignalR(hubConfiguration);
                });
            }
`
