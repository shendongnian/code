cs
public interface IService { }
public class FooService : IService { }
// And more implementations of IService...
The service factory:
cs
public interface IServiceFactory
{
    IEnumerable<IService> GetServices();
}
public class ServiceFactory : IServiceFactory
{
    public ServiceFactory(MyWebservice myWebservice) { }
    public IEnumerable<IService> GetServices()
    {
        // Use MyWebservice to conditionally create the desired IService instances
        // or use any other type of logic.
    }
}
After you add the `IServiceFactory` to your dependency injection container, you can inject it and use it to resolve the `IService` instances:
cs
public class SomeController
{
    public SomeController(IServiceFactory serviceFactory) { }
    public IActionResult Get()
    {
        var services = _serviceFactory.GetServices();
        // Do something with the created IService instances...
    }
}
