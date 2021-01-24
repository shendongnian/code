        public sealed class Singleton
    {
        private static Singleton m_oInstance = null;
        private int m_nCounter = 0;
     
        public static Singleton Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new Singleton();
                }
                return m_oInstance;
            }
        }
     
        public void DoSomething()
        {
            Console.WriteLine("Hello World {0}!", m_nCounter++);
        }
     
        private Singleton()
        {
            m_nCounter = 1;
        }
    }
