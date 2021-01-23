    public class EnumBase
    {
        public int Val { get; private set; }
        public string Description { get; private set; }
        private static readonly Dictionary<int, EnumBase> ValueMap = new Dictionary<int, EnumBase>();
        protected EnumBase(int v, string desc)
        {
            Description = desc;
            Val = v;
        }
        protected static void BuildDictionary<T>()
        {
            
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                ValueMap.Add(((EnumBase)field.GetValue(null)).Val, (EnumBase)field.GetValue(null));
            }
        }
        public static EnumBase ValueOf(int i)
        {
            return ValueMap[i];
        }
    }
