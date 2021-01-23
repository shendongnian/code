    protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
    
            if (Request.QueryString["url"] == null)
                return;
            string url = "www." + Request.QueryString["url"].ToString().Replace("http://", "").Replace("https://", "").Replace("www.", "").ToLower();
            
    
            Response.AddCacheItemDependency(url);
        }
