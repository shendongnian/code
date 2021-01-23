    class Singleton
    {
        private static Singleton instance;
        private static int numReferences;
    
        private Singleton()
        {
            numReferences = 0;
        }
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            numReferences++;
            return instance;
        }
        public static int ReferenceCount
        {
            get { return numReferences; }
        }
    }
