    protected void Page_Init(object Sender, EventArgs e)
    {
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
    Response.Cache.SetNoStore();
    }
