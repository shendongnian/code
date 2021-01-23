    public static class MyData
    {
        public static MyObject Item1 { 
            get { return HttpContext.Current.Session["DataKey"] as MyObject;}
            set { HttpContext.Current.Session["DataKey"] = value;}
        }
    }
