    If(Session["UserId"] == "")
    {
       Response.ExpiresAbsolute = (DateTime.Now.AddDays(-1));
       Response.AddHeader("pragma", "no-cache");
       Response.AddHeader("cache-control", "private");
       Response.CacheControl = "no-cache";
    }
