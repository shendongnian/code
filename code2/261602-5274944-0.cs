    public class StructureMapServiceProvider: IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return ObjectFactory.GetInstance(serviceType);
        }
        public T GetService<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
