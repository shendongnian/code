c#
IWebHost CreateWebHost(out ServiceDescriptor[] allServices)
{
    ServiceDescriptor[] grabbedServices = null;
    var host = new WebHostBuilder()
        // ... other stuff ...
        .UseStartup<Startup>()
        // add the following call:
        .ConfigureServices(services => {
            // copy all service descriptors
            grabbedServices = services.ToArray(); 
        })
        // build the host now to trigger the above chain
        .Build();
    allServices = grabbedServices;
    return host;
}
