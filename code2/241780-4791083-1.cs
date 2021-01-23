    public interface ISomeInterface
    {
        void SomeMethod();
    }
    public abstract class BaseClassWithInterface : ISomeInterface
    {
        public abstract void SomeMethod();
    }
    public class ClassForTestingWithInterface
    {
        public ISomeInterface SomeMember { get; private set; }
        public ClassForTestingWithInterface(ISomeInterface baseClass) {...}
    }
