    public class Foo : ISome
    {
        public T Get<T>() where T:class
        {
            if (!typeof(ISomeInterface).IsAssignableFrom(typeof(T))) throw new Exception();
            return (T)typeof(SomeStaticClass).GetMethod("Create").MakeGenericMethod(new [] {typeof(T)}).Invoke();
        }
    }
