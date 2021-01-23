    public class MySingleton
    {
        private static MySingleton m_instance;
        private MySingleton() 
        {
            // load data from config file 
        }
        public static MySingleton Instance 
        { 
            get 
            {
                 if(m_instance == null)
                 {
                     m_instance = new MySingleton();
                 } 
                 return m_instance; 
            }
        }
    }
