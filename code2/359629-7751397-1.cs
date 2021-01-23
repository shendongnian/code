    public int? TotalRecords
    {
        get {
            return (int?) HttpContext.Current.Session["TotalRecords"];
        }
        set {
            HttpContext.Current.Session["TotalRecords"] = value;
        }
    }
