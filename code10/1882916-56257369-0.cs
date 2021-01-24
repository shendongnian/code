public class MyPackageInstaller
{
    public void Install(IServiceCollection services)
    {
        // Your package registers its services
    }
}
Then this can also be a point where you allow the consumer to make optional changes. For example, you could define a class like this which allows the consumer to specify implementations for certain services:
    public class MyPackageRegistrationOptions
    {
        public ServiceDescriptor FooServiceDescriptor { get; private set; }
        public void AddFooService(ServiceDescriptor fooDescriptor)
        {
            if (fooDescriptor.ServiceType != typeof(IFooService))
            {
                throw new ArgumentException("fooDescriptor must register type IFooService.");
            }
            FooServiceDescriptor = fooDescriptor;
        }
    }
Now your installer can take those options, and register either the implementation specified by the consumer or its own default.
    public class MyPackageInstaller
    {
        private readonly MyPackageRegistrationOptions _options;
        public MyPackageInstaller(MyPackageRegistrationOptions options = null)
        {
            _options = options;
        }
        public void Install(IServiceCollection services)
        {
            if (_options?.FooServiceDescriptor != null)
                services.Add(_options.FooServiceDescriptor);
            else 
                 // here's your default implementation
                services.AddSingleton<FooService>();
        }
    }
Usage:
    var services = new ServiceCollection();
    var options = new MyPackageRegistrationOptions();
    options.AddFooService(ServiceDescriptor.Singleton<IFooService, AlternateFooService>());
    var installer = new MyPackageInstaller(options);
    installer.Install(services);
At first glance it looks like a longer way to get the same result. The benefit is that it allows you to make it clearer which services should or should not be overridden. That way it feels more like you're working with deliberately exposed configuration options and less like poking at the internals of the package. 
Instead of allowing the consumer to add a `ServiceDescriptor` you could allow them to specify only a service type, and your configuration determines how it gets registered (singleton, transient, etc.)
This is also a helpful pattern when the library depends on configuration values like connection strings which must be supplied by the consumer. You can make them required arguments to construct options and then require the options to construct the installer, or just make them required arguments in the installer. Now it's impossible to install the package without the needed configuration values.
