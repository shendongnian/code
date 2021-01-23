    public int? TotalRecords
    {
        get {
            return HttpContext.Current.Session["TotalRecords"];
        }
        set {
            HttpContext.Current.Session["TotalRecords"] = value;
        }
    }
