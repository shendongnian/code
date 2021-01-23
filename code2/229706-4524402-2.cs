    class Singleton
    {
        private static Singleton instance;
        private static int usageCount;
    
        private Singleton()
        {
            usageCount= 0;
        }
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            usageCount++;
            return instance;
        }
        public static int UsageCount
        {
            get { return usageCount; }
        }
    }
