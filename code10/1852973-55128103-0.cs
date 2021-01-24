    public class BaseDoc
    {
        protected virtual Dictionary<string, string> Props { get; } = new Dictionary<string, string>()
        {
            { "PropA", null },
            { "PropB", "defXyz" },
            { "PropC", "defCCC" }
        };
        protected virtual Dictionary<PropN, string> Props2 { get; } = new Dictionary<PropN, string>()
        {
            { PropN.PropA, null },
            { PropN.PropB, "defXyz" },
            { PropN.PropC, "defCCC" }
        };
        public IReadOnlyDictionary<string, string> PropsReadOnly => Props;
        public IReadOnlyDictionary<PropN, string> Props2ReadOnly => Props2;
    }
    public class PropN
    {
        private PropN(string name) => Name = name;
        
        public string Name { get; }
        public static readonly PropN PropA = new PropN("PropA");
        public static readonly PropN PropB = new PropN("PropB");
        public static readonly PropN PropC = new PropN("PropC");
    }
