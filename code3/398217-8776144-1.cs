    public sealed class RewriterHttpModule : IHttpModule
        {
        private static RewriterEngine _rewriter = new RewriterEngine();
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(BeginRequest);
        }
        private void BeginRequest(object sender, EventArgs e)
        {
           var context=((HttpApplication)sender).Context;
           string path = context.Request.Path;
           /*
             url rewrite list: 
              Dictionary<string,string>
           */
            Dictionary<string, string> urls = new Dictionary<string, string>();
            urls.Add(@"/store/description/product?table=page(\d+)", "/store/description/product?id=$1");
            foreach (var pair in urls)
            {
                if (Regex.IsMatch(path, pair.Key))
                {
                    var newUrl = Regex.Replace(path, pair.Key, pair.Value);
                    //rewrite url
                    context.RewritePath(newUrl, false);
                }
            }
        }
    }
