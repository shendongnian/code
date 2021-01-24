    public class MyClass
    {
        private List<string> m_Values;
    
        ...
    
        public IEnumerable<string> Values { 
          get {
            // Instead of enumerating and computing items
            // we return the collection of computed items
            return m_Values;
          }
          private set {
            // Now value will be enumerated once and items
            // will be stored in the m_Values collection
            m_Values = value.ToList();
          }
        }
    
        ... 
    }
