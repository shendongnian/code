    protected void Page_Load(object sender, EventArgs e)
    {
        var fb = new FacebookApp();
        var auth = new CanvasAuthorizer(fb);
        if (!auth.IsAuthorized())
        {
            var url = auth.GetLoginUrl(new HttpRequestWrapper(Request));
            var content = CanvasUrlBuilder.GetCanvasRedirectHtml(url);
            Response.ContentType = "text/html";
            Response.Write(content);
            Response.End();
            return;
        }
        //...Go on if authorized
    }
