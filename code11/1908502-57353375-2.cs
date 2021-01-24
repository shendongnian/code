c#
using Microsoft.AspNetCore.TestHost;
....
IWebHost CreateWebHost(out ServiceDescriptor[] allServices)
{
    ServiceDescriptor[] grabbedServices = null;
    var host = new WebHostBuilder()
        // ... other stuff ...
        .UseStartup<Startup>()
        // add the following call:
        .ConfigureTestServices(services => {
            // copy all service descriptors
            grabbedServices = services.ToArray(); 
        })
        // build the host now to trigger the above chain
        .Build();
    allServices = grabbedServices;
    return host;
}
It is then convenient to use like this:
c#
[Fact]
public void TestSomething()
{
    // arrange
    var host = CreateWebHost(out var services);
    // ... do something with the services
    // act
    // assert    
}
The reason we have to use `ConfigureTestServices` (and not `ConfigureServices`) is that `ConfigureServices` is always invoked before the methods in the `Startup` class, whereas `ConfigureTestServices` is invoked afterward.
### UPDATE
Of course, it's also possible to just store the reference to `ServiceCollection` in a variable/field, and enumerate the services whenever necessary.
