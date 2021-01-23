    public class Token
    {
        private Dictionary<string, string> _attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public string InnerText { get; private set; }
        public string this[string attributeName]
        {
            get
            {
                string val;
                _attributes.TryGetValue(attributeName, out val);
                return val;
            }
        }
        public Token(string innerText, IEnumerable<KeyValuePair<string, string>> values)
        {
            InnerText = innerText;
            foreach (var item in values)
            {
                _attributes.Add(item.Key, item.Value);
            }
        }
        public int GetInteger(string name, int defaultValue)
        {
            string val;
            int result;
            if (_attributes.TryGetValue(name, out val) && int.TryParse(val, out result))
                return result;
            return defaultValue;
        }
    }
