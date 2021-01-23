    public class StatusType : IEnumerable<KeyValuePair<int, string>>
    {
          private readonly List<KeyValuePair<int, string>> entries = new List<KeyValuePair<int, string>>();
        public void Add(int key, string value)
        {
            this.entries.Add(new KeyValuePair<int, string>(key, value));
        }
        public string this[int key]
        {
            get
            {
                foreach (var kvp in this.entries)
                {
                    if (string.Compare(kvp.Key, key, StringComparison.Ordinal) == 0)
                    {
                        return kvp.Value;
                    }
                }
                return null;
            }
        }
    }
