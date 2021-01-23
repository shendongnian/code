    class MyClass
    {
        private static MyClass m_Instance = new MyClass();
        public static MyClass Instance
        {
            get { return m_Instance; }
        }
    }
