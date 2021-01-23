    public class ErrorHandleModule : IHttpModule
        {
    
            private static readonly ILog logger = LogManager.GetLogger("Citiport.Web.Module.ErrorHandleModule");
    
            public ErrorHandleModule()
            {
    
            }
    
            void IHttpModule.Dispose()
            {
            }
    
            void IHttpModule.Init(HttpApplication context)
            {
                context.Error += new System.EventHandler(onError);
            }
    
            public void onError(object obj, EventArgs args)
            {
    			HttpContext ctx = HttpContext.Current;
    			HttpResponse response = ctx.Response;
    			HttpRequest request = ctx.Request;
    
    			Exception exception = ctx.Server.GetLastError();
    			/* handling exception here*/
            }
        }
    }
