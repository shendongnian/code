        public class NoIndexHttpModule : IHttpModule
        {
          public void Dispose() { }
        
          public void Init(HttpApplication context)
          {
            context.PreRequestHandlerExecute += AttachNoIndexMeta;
          }
        
          private void AttachNoIndexMeta(object sender, EventArgs e)
          {
            var page = HttpContext.Current.CurrentHandler as Page;
            if (page != null && page.Header != null)
            {
              page.Header.Controls.Add(new LiteralControl("<meta name=\"robots\" value=\"noindex, follow\" />"));
            }
          }
    
    }
