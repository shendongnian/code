    public static NinjectResolver GetInstance()
    {   
        if(instance == null)
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new NinjectResolver();
            }
        }
        return instance;
    }
