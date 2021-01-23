    public class CustomModule : IHttpModule
    {
      public void Init(HttpApplication context)
      {
        context.ReleaseRequestState += new EventHandler(context_ReleaseRequestState);
      }
      private void context_ReleaseRequestState(object sender, EventArgs e)
      {
        HttpResponse response = HttpContext.Current.Response;
        if (string.Compare(response.ContentType,"text/html",true) == 0)
        {
          response.Filter = new CustomFilter(response.Filter,response.ContentEncoding);
        }
      }
    }
