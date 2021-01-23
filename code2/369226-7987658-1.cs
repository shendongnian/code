    public class MyClass
    {
        public static MyClass StaticVar
        {
            get
            {
                var s = HttpContext.Current.Session["MyClass"] as MyClass;
                if ( s==null )
                {
                    s = new MyClass();
                    HttpContext.Current.Session["MyClass"] = s;
                }
                return s;
            }
        }
    }
