    public static class StaticVariables
    {
        public static int foo { get {return values["foo"];}}
        public static int bar { get {return values["bar"];}}
        public static int bazinga { get {return values["bazinga"];}}
        
        private static Dictionary<String,int> values = new Dictionary<String,int>();
        
        static StaticVariables()
        {
        	values.Add("foo",0);
        	values.Add("bar",0);
        	values.Add("bazinga",0);
        }
        
        public static void DoStuff()
        {
        	values["foo"] =30;
        	values["bar"] =23;
        }
    }
