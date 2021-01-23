    public interface IDependencyResolver
    {
        T Resolve<T>();
    }
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;
        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
