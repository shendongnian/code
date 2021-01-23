    public class Factory
    {
        public T CreateObject<T>() where T : Foo, new()
        {
            T t = new T();
            t.GetType()
             .GetField("parent", BindingFlags.NonPublic | BindingFlags.Instance)
             .SetValue(t, this);
            return t;
        }
    }
