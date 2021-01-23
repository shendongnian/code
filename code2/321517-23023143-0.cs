       public class globals
        {
            static string _test = "MyTest";
            public static string test 
            {
                get
                 {
                    return _test;
                 }
                set
                 {
                    _test = value;
                 }
            }
