    public static class SessionVars
    {
         public static Dictionary<DateTime> DateCollections
         {
            get { return (Dictionary<DateTime>)HttpContext.Current.Session["DateCollections"]; }
            set { HttpContext.Current.Session["DateCollections"] = value; }
         }
    }
