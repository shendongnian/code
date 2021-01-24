    public class UserDetails
    {
        private Dictionary<string, object> Items { get; } = new Dictionary<string, object>();
        public object this[string prop]
        {
            get
            {
                if (Items.TryGetValue(prop, out object o))
                {
                    return o;
                }
                return null;
            }
            set
            {
                if (Items.ContainsKey(prop))
                {
                    Items[prop] = value;
                    return;
                }
                Items.Add(prop, value);
            }
        }
        public int? Level
        {
            get => (int?)this["Level"];
            set => this["Level"] = value;
        }
    }
