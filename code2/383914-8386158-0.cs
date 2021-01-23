    static Singleton()
        {
        if (instance == null)
            {
            instance = new Singleton();
            mutex = new System.Threading.Mutex();
            }
        }
