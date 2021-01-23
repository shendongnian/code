    public class InjectorFactory : IFactory<T> 
    {
        // we wrapped the Kernel in an Injector class
        public T Get() { return Injector.Get<T>(); } 
    }
