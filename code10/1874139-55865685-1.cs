    public class UserDetails
    {
        private Dictionary<string, object> Items { get; } = new Dictionary<string, object>();
        public object this[string propertyName]
        {
            get => Items.TryGetValue(propertyName, out object obj) ? obj : null;
            set => Items[propertyName] = value;
        }
        public int? Level
        {
            get => (int?)this["Level"];
            set => this["Level"] = value;
        }
    }
