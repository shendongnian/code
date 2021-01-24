public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        }).UseServiceProviderFactory(new AutofacServiceProviderFactory());
then add ConfigureContainer in StartUp.cs
public void ConfigureContainer(ContainerBuilder builder)
{
    builder.RegisterAssemblyTypes(typeof(Program).Assembly).
        Where(x => x.Name.EndsWith("service", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
            builder.RegisterDynamicProxy();
}
in dotnet core 3.0 change ioc way
