    private IDBContext DBContext;
    public MyHTTPModule()
    {
        DBContext = Global.Container.GetInstance<IDBContext>();
    }
