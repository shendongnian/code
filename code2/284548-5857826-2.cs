    protected void Application_BeginRequest(object sender, EventArgs ev)
    {
        if (!Request.Url.Host.StartsWith("www", StringComparison.InvariantCultureIgnoreCase))
        {
            Response.Clear();
            Response.AddHeader("Location", 
                String.Format("{0}://www.{1}{2}", Request.Url.Scheme, Request.Url.Host, Request.Url.PathAndQuery)
                );
            Response.StatusCode = 301;
            Response.End();
        }
    }
