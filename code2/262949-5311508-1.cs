    public class StubDataProvider : IDataProvider
    {
        public T GetDataDocument<T>(Guid document) where T : class, new()
        {
            return new T();
        }
    }
