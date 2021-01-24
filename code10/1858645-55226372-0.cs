    public class UserInfo
    {
        private IDictionary<string, object> _dictionary = new Dictionary<string, object>();
        public string FirstName
        {
            get
            {
                object value;
                return _dictionary.TryGetValue(nameof(FirstName), out value) ? (string)value : null;
            }
            set
            {
                _dictionary[nameof(FirstName)] = value;
            }
        }
        public string LastName
        {
            get
            {
                object value;
                return _dictionary.TryGetValue(nameof(LastName), out value) ? (string)value : null;
            }
            set
            {
                _dictionary[nameof(LastName)] = value;
            }
        }
        public int Age
        {
            get
            {
                object value;
                return _dictionary.TryGetValue(nameof(Age), out value) ? (int)value : 0;
            }
            set
            {
                _dictionary[nameof(Age)] = value;
            }
        }
        public object this[string property]
        {
            set
            {
                //todo: validation if needed
                _dictionary[property] = value;
            }
        }
