    public interface IFoo { ... }
    public class Foo { ... }
    
    public class ServiceLocator
    {
        IFoo _foo = new Foo();
        public IFoo GetFoo() { return _foo; }
    }
    public class DependsOnFoo
    {
        public IFoo Foo = ServiceLocator.GetFoo();
        ...
    }
