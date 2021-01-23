    public void Init(HttpApplication app)
    {
       app.BeginRequest += new EventHandler(OnBeginRequest);
       app.EndRequest += new EventHandler(OnEndRequest);
    }
