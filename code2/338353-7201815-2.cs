    public class UnityDependencyResolver : IDependencyResolver
    {
      private readonly IUnityContainer container;
      public UnityDependencyResolver(IUnityContainer container)
      {
        this.container = container;
      }
      #region IDependencyResolver Members
      public object GetService(Type serviceType)
      {
        try
        {
          return container.Resolve(serviceType);
        }
        catch
        {
          return null;
        }
      }
    // ..
    }
