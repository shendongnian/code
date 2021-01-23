    public static class f
    {
        public static bool IsGuest 
        {
            get
            {
                return HttpContext.Current.Session["uid"] == null;
            }
        }
        public static bool IsAdmin
        {
            get
            {
                return HttpContext.Current.Session["admin"] != null;
            }
        }
        //...
    }
