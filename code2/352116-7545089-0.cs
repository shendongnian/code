    public class MyList<T> : IList<T>
    {
        // Keep a normal list that does the job.
        private List<T> m_List = new List<T>();
    
        // Forward the method call to m_List.
        public Insert(int index, T t) { m_List.Insert(index, t); }
    
        public Add(T t)
        {
            // Your special handling.
        }
    }
