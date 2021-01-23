        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
                SiteMapDataSource1.Provider = SiteMap.Providers("admin");
            else
                SiteMapDataSource1.Provider = SiteMap.Providers("user");
        }
        else
            SiteMapDataSource1.Provider = SiteMap.Providers("anonymous");
