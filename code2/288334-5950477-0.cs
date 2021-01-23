    class singleton
    {
        private static singleton instance = new singleton();
        private static singleton() { }
    
        public static singleton Instance
        {
            get { return instance; }
        }
    }
