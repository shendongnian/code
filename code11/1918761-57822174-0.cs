c#
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory());
}
Registered provider will **automatically** wrap all standard services registered in `void ConfigureServices(IServiceCollection services)` method. There is **no need** for lines:
c#
public void ConfigureContainer(ContainerBuilder builder)
{
    // ...
    builder.Populate(services);
    // ...
    return new AutofacServiceProvider(this.ApplicationContainer);
}
To **add additional** Autofac-specific **registrations**, `ConfigureContainer(ContainerBuilder builder)` method on startup class can be used:
c#
public partial class Startup
{
    public void ConfigureContainer(Autofac.ContainerBuilder builder)
    {
        builder.RegisterModule<MyModule>();
    }
}
Additional info can be found in this [Github issue][1].
  [1]: https://github.com/dotnet/core/issues/2828
