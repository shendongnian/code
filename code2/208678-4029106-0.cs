    public class Module : IHttpModule, IRequiresSessionState
    {
        public void Dispose()
        {
        }
    
        void OnPostMapRequestHandler(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
    
            if (app.Context.Handler is IReadOnlySessionState || app.Context.Handler is IRequiresSessionState)
                return;
    
            app.Context.Handler = new MyHttpHandler(app.Context.Handler);
        }
    
        void OnPostAcquireRequestState(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
    
            MyHttpHandler resourceHttpHandler = HttpContext.Current.Handler as MyHttpHandler;
    
            if (resourceHttpHandler != null)
                HttpContext.Current.Handler = resourceHttpHandler.OriginalHandler;
        }
    
        public void Init(HttpApplication httpApp)
        {
            httpApp.PostAcquireRequestState += new EventHandler(OnPostAcquireRequestState);
            httpApp.PostMapRequestHandler += new EventHandler(OnPostMapRequestHandler);
        }
    
        public class MyHttpHandler : IHttpHandler, IRequiresSessionState
        {
            internal readonly IHttpHandler OriginalHandler;
    
            public void ProcessRequest(HttpContext context)
            {
                throw new InvalidOperationException("MyHttpHandler cannot process requests.");
            }
    
            public MyHttpHandler(IHttpHandler originalHandler)
            {
                OriginalHandler = originalHandler;
            }
    
            public bool IsReusable
            {
                get { return false; }
            }
        }
    }
