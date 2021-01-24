    void Application_BeginRequest(Object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.IsLocal)
            return;
        if (!Request.IsSecureConnection)//always https!!!
        {
            var _nfn = "https://" + (Request.Url.Host + Request.RawUrl).ToLowerInvariant();
            Response.RedirectPermanent(_nfn);
            return;
        }
    }
