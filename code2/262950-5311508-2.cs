    public class MockDataProvider : IDataProvider
    {
        private readonly Action _action;
        public MockDataProvider(Action action)
        {
            _action = action;
        }
        public T GetDataDocument<T>(Guid document) where T : class, new()
        {
            _action();
            return new T();
        }
    }
