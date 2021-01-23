    public interface ICanBeSerialized
    {
        // this interface is left intentionally blank
    }
    
    public class Value : ICanBeSerialized
    {
        // do whatever
    }
    public class MyClass 
    {
        public void Foo<T>() where T : ICanBeSerialized
        { }
    }
