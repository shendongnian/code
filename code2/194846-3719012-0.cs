    public class Foo : ISome
    {
        public T Get<T>() where T : class
        {
            return SomeStaticClass.Create<ISomeInterface>() as T; 
        }
    }
