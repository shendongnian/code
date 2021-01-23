    public class CdnModule : IHttpModule
    {
        void IHttpModule.Dispose()
        {
        }
        void IHttpModule.Init(HttpApplication context)
        {
            context.ReleaseRequestState += new EventHandler(context_ReleaseRequestState);
        }
        void context_ReleaseRequestState(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Filter = new CdnFilter(HttpContext.Current.Response.Filter);
        }
    }
