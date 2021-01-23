    public static Dictionary<int, int[]> RecentAssetLists
    {
        get
        {
            var session = HttpContext.Current.Session;
            var dict = session["RECENT_ASSET_LISTS"];
            if (dict == null)
            {
                dict = new Dictionary<int, int[]>();
                session["RECENT_ASSET_LISTS"] = dict; 
            }
            return dict;
        }
    }
