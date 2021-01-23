    private bool initialised;
    private object lockObject = new object();
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
