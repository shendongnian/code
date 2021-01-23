    public class FooRepository<T>
    {
        private IDictionary<int, IList<T>> m_repository;
    
        FooRepository()
        {
            m_repository = new Dictionary<int, List<T>>();
        }
    
        public Add(int key, IList<T> value)
        {
            m_repository.Add(key, value);
        }
    
        // other public methods to expose
    }
