    namespace StaticBinding
    {
        public class MyStaticClass
        {
            private static string myStaticProperty = "my static text";
            public static string MyStaticProperty
            {
                get { return myStaticProperty; }
                set { myStaticProperty = value; }
            }
        }
    }
