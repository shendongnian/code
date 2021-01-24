public interface IContainer 
{
   T Resolve<T>();
}
public class ServiceProviderContainer : IContainer 
{
  private IServiceProvider _serviceProvider; 
  public ServiceProviderContainer(IServiceProvider serviceProvider)
  {
    this._serivceProvider = serviceProvider;
  }
  
  public T Resolve<T>()
  {
     return _seriveProvider.GetService<T>();
  }
}
public class MyController : Controller 
{ 
  private IContainer contianer;
  public MyController(IContainer container)
  {
    this._container = container;
  }
  
  public IActionResult Get()
  {
    var service = _container.Resolve<IUserRepository>();
  }
}
