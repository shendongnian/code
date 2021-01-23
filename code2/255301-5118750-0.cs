    public static class GlobalVariables
    {
        // readonly variable
        public static string Foo
        {
            get
            {
                return "foo";
            }
        }
        // read-write variable
        public static string Bar
        {
            get
            {
                return HttpContext.Current.Application["Bar"] as string;
            }
            set
            {
                HttpContext.Current.Application["Bar"] = value;
            }
        }
    }
