public static void ConfigureServices(IServiceCollection services)
{
    //this was added
    services.AddSingleton(new BackgroundJobServerOptions()
    {
        //you can change your options here
        Queues = new[] { "etl" }
    });
    services.AddHangfire(config =>
    {
        config.UsePostgreSqlStorage();
    });
    services.AddHangfireServer();
}
