    private static volatile NinjectResolver instance = new NinjectResolver();
    public static NinjectResolver GetInstance()
    {
        return instance;
    }
