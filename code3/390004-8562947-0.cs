    public class MySingleton
    {
        private static MySingleton m_instance;
        private MySingleton() { }
        public static MySingleton Instance 
        { 
            get 
            {
                 if(m_instance == null)
                 {
                     // hydrate m_instance from serialized version
                 } 
                 return m_instance; 
            }
        }
    }
