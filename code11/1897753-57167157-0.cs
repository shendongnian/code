public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();
    Dependencies.RegisterDependencies(services);
}
Then, in `Program.cs` set `RegisterDepenedencies` to register the dependencies you need:
public static void Main(string[] args)
{
    Dependencies.RegisterDependencies = s =>
    {
        s.AddSingleton<IWeatherForecastService, WeatherForecastService>();
    };
    CreateHostBuilder(args).Build().Run();
}
You can now change this method in the test project to configure different dependencies when running integration tests. In your test project:
Dependencies.RegisterDependencies = s =>
{
    s.AddSingleton<IWeatherForecastService, MockWeatherForecastService>();
};
**This is very hacky, hopefully the `ContentRoot` issue is fixed, then changing the content root to the main project should be used instead**
  [1]: https://github.com/aspnet/AspNetCore/issues/11921
