    public sealed class Colors 
    {
        public int Val { get; private set; }
        public string Description { get; private set; }
        private static readonly Dictionary<int, Colors> ValueMap = new Dictionary<int, Colors>();
        static Colors()
        {
            BuildDictionary<Colors>();
        }
        private static void BuildDictionary<T>()
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                ValueMap.Add(((Colors)field.GetValue(null)).Val, (Colors)field.GetValue(null));
            }
        }
        public static Colors ValueOf(int i)
        {
            return ValueMap[i];
        }
        private Colors(int v, string desc)
        {
            Description = desc;
            Val = v;
        }
        public static readonly Colors Red = new Colors(0, "Red");
        public static readonly Colors Green = new Colors(1, "Green");
        public static readonly Colors Blue = new Colors(2, "Blue");
        public static readonly Colors Yellow = new Colors(3, "Yellow");
    }
