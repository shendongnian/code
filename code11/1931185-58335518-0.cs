[Fact]
public async Task LoadWeatherForecastAsync()
{
    var webHostBuilder = new WebHostBuilder()
        .UseContentRoot(AppContext.BaseDirectory)
        .ConfigureAppConfiguration(builder =>
        {
            builder.Sources.Clear();
            builder.SetBasePath(AppContext.BaseDirectory);
            // this is an appsettings file located in the test-project!
            builder.AddJsonFile("appsettings.Testing.json", false);
        })
        .UseStartup<Startup>();
    var host = new TestServer(webHostBuilder);
    var response = await host.CreateClient().GetAsync("weatherforecast");
    
    Assert.True(response.IsSuccessStatusCode);
}
I've created a sample on [github][1]. You can clone it and try it out.
  [1]: https://github.com/alsami/AspNetCore.WebApi.Testing
