    public static List<string> RecentAssetList   
    {   
        get   
        {   
            if (HttpContext.Current.Session["RECENT_ASSET_LIST"] == null)
                HttpContext.Current.Session["RECENT_ASSET_LIST"] = new List<string>();
    
            return HttpContext.Current.Session["RECENT_ASSET_LIST"].ToString();   
        }   
        set   
        {   
            HttpContext.Current.Session["RECENT_ASSET_LIST"] = value;   
        }   
    }   
