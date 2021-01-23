    public class PropertyMap<T> where T : new()
    {
        public void Add(string sourceName, Expression<Func<T, object>> getProperty);
        public T CreateObject(IDictionary<string, object> values);
    }
