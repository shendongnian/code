        <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="2.2.*" />
    so that we could enable logging to troubleshoot :
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(UrlBuilder.BuildEndpoint("Notifications"))
            .ConfigureLogging(logging =>{
                logging.AddConsole();        // enable logging
            })
            .Build();
