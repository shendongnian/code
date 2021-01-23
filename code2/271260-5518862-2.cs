    private static bool initialised;
    private static object lockObject = new object();
    public void Init(HttpApplication app)
    {
        lock(lockObject)
        {
             if(!initialised)
             {
               app.BeginRequest += ProcessRequest;
               //... other code here
               initialised = true;
             }
        }
    }
