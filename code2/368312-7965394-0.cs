    public class SomeClass { }
    public class SomeDerivedClass : SomeClass { }
    public interface IFactory<T>
    {
        public T Create();
    }
    public class SomeClassFactory : IFactory<SomeClass>
    {
        public SomeClass Create() { return new SomeClass(); }
    }
    public class SomeDerivedClassFactory : IFactory<SomeDerivedClass>
    {
        public SomeDerivedClass Create() { return new SomeDerivedClass(); }
    }
