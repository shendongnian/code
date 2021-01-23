    public static class SomeStaticClass
    {
        public static T Create<T>() where T:class
        {
            //Replace with actual construction of T
            return (T)(new object());
        }
    }
    
    public interface ISome
    {
        T Get<T>() where T : class;
    }
    
    public class Foo : ISome
    {
        public T Get<T>() where T:class
        {
            return SomeStaticClass.Create<T>(); 
        }
    }
