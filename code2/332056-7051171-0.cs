    public class ConvertibleKeyValuePair
    {
        public ConvertibleKeyValuePair(string key, int value)
        {
            _key = key;
            _value = value;
        }
    
        public static implicit operator ConvertibleKeyValuePair(string s)
        {
            string[] parts = s.Split(';');
            if (parts.Length != 2) {
                throw new ArgumentException("ConvertibleKeyValuePair can only convert string of the form \"key;value\".");
            }
            int value;
            if (!Int32.TryParse(parts[1], out value)) {
                throw new ArgumentException("ConvertibleKeyValuePair can only convert string of the form \"key;value\" where value represents an int.");
            }
            return new ConvertibleKeyValuePair(parts[0], value);
        }
    
        private string _key;
        public string Key { get { return _key; } }
    
        private int _value;
        public int Value { get { return _value; } }
    
    }
    
