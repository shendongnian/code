    public static class Dvar 
    {
        private static IDictionary<string, int> map = new Dictionary<string, int>();
    
        public static int this[string key]
        {
            get { return map[key]; }
            set { map[key] = value; }
        }
    }
