    public  class UrlModule : IHttpModule
        {
            public virtual void Init(HttpApplication application)
            {
                application.BeginRequest += new EventHandler(this.BaseUrlModule_BeginRequest);
            }
            public virtual void Dispose()
            {
            }
            protected virtual void BaseUrlModule_BeginRequest(object sender, EventArgs e)
            {
                HttpApplication application = (HttpApplication)sender;
                Rewritethepath(application.Request.Path, application);
            }
    
            private  void Rewritethepath(string requestedPath, HttpApplication application)
            {
               application.Context.RewritePath("/yournewurl", String.Empty, QueryString);                
            }
        }
