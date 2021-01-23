    public class TestContainer<T>
    {
        private readonly List<T> _list;
        public TestContainer()
        {
            _list = new List<T>();
        }
        public void Add()
        {
            _list.Add(default(T));
        }
    }
