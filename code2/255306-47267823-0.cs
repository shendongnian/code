    public static class GlobalVars
    {
        private const string GlobalKey = "AllMyVars";
        static GlobalVars()
        {
            Hashtable table = HttpContext.Current.Application[GlobalKey] as Hashtable;
            if (table == null)
            {
                table = new Hashtable();
                HttpContext.Current.Application[GlobalKey] = table;
            }
        }
        public static Hashtable Vars
        {
            get { return HttpContext.Current.Application[GlobalKey] as Hashtable; }
        }
        public static IEnumerable<SomeClass> SomeCollection
        {
            get { return GetVar("SomeCollection") as IEnumerable<SomeClass>; }
            set { WriteVar("SomeCollection", value); }
        }
        internal static DateTime SomeDate
        {
            get { return (DateTime)GetVar("SomeDate"); }
            set { WriteVar("SomeDate", value); }
        }
        private static object GetVar(string varName)
        {
            if (Vars.ContainsKey(varName))
            {
                return Vars[varName];
            }
            return null;
        }
        private static void WriteVar(string varName, object value)
        {
            if (value == null)
            {
                if (Vars.ContainsKey(varName))
                {
                    Vars.Remove(varName);
                }
                return;
            }
            if (Vars[varName] == null)
            {
                Vars.Add(varName, value);
            }
            else
            {
                Vars[varName] = value;
            }
        }
    }
