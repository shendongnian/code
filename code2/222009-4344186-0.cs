    public void Init(HttpApplication context)
    {
        context.BeginRequest += new EventHandler(context_BeginRequest);
    }
    void context_BeginRequest(object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)sender;
        application.Context.Response.Redirect("http://vls.pete.videolibraryserver.com");
    }
