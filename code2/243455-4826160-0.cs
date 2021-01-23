    public static Singleton Instance
    {
       get { return instance; }
    }
    public static DoSomething()
    {
        instance = new Singleton();
    }
