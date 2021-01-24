    public class MyClass
    {
        private List<string> m_ValuesList;
        private IEnumerable<string> m_Values; 
    
        ...
    
        public IEnumerable<string> Values { 
          get {
            // Materialize if cache doesn't exist
            if (m_ValuesList == null)
              m_ValuesList = m_Values.ToList();
            // Instead of enumerating and computing items
            // we return the collection of computed items 
            return m_ValuesList;
          }
          private set {
            m_Values = value;
            // drop cache (materialized collection) 
            m_ValuesList = null;
          }
        }
    
        ... 
    }
