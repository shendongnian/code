public void ConfigureServices(IServiceCollection services)
{
    services.AddSignalR(hubOptions =>
    {
        hubOptions.ClientTimeoutInterval = TimeSpan.FromMinutes(30);
        hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(15);
    });
}
Or for a single hub:
services.AddSignalR().AddHubOptions<MyHub>(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromMinutes(30);
    options.KeepAliveInterval = TimeSpan.FromMinutes(15);
});
