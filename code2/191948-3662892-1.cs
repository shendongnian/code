    // define a simple factory interface
    public interface IFactory
    {
        object CreateInstance();
    }
    // and a generic one (hey, why not?)
    public interface IFactory<T> : IFactory
    {
        new T CreateInstance();
    }
    // define a Factory attribute that will be used to identify the concrete implementation of a factory
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FactoryAttribute : Attribute
    {
        public Type FactoryType { get; set; }
        public FactoryAttribute(Type factoryType)
        {
            this.FactoryType = factoryType;
        }
    }
