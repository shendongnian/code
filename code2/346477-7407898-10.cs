    class MyClass
    {
        public bool Initialized;
        public MyClass()
        {
            Initialized = true;
        }
    }
    MyClass instance = null;
    public MyClass GetInstance()
    {
        if (instance == null)
        {
            lock (something)
            {
                if (instance == null)
                {
                    instance = new Class();
                }
            }
        }
        return instance;
    }
