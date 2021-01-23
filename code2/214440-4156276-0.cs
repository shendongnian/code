    public class Converter
    {
        private readonly char[] _map;
        public Converter()
        {
            // This code assumes char to be a short unsigned integer
            _map = new char[65536];
            for (int i = 0; i < _map.Length; i++)
                _map[i] = (char) i;
            _map[(uint) 'å'] = 'a';
            _map[(uint) 'Å'] = 'A';
            _map[(uint) 'æ'] = 'a';
            // ... the rest of overriding map
        }
        public string Convert(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            var sb = new StringBuilder(source.Length); // ensure proper size
            foreach (char c in source)
                sb.Append(_map[(uint) c]); // convert using the map
            return sb.ToString();
        }
    }
