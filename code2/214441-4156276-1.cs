    public class Converter
    {
        private readonly char[] _map;
        public Converter()
        {
            // This code assumes char to be a short unsigned integer
            _map = new char[char.MaxValue];
            for (int i = 0; i < _map.Length; i++)
                _map[i] = (char)i;
            _map['å'] = 'a';
            _map['Å'] = 'A';
            _map['æ'] = 'a';
            // ... the rest of overriding map
        }
        public string Convert(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            var result = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
                result[i] = _map[source[i]]; // convert using the map
            return new string(result);
        }
    }
