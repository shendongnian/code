    public class MyClass
    {
        public static MyClass StaticVar
        {
            get
            {
                var s = Session["MyClass"] as MyClass;
                if ( s==null )
                {
                    s = new MyClass();
                    Session["MyClass"] = s;
                }
                return s;
            }
        }
    }
