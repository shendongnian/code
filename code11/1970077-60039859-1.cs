    public class NoDupeObject
    {
        private static readonly Dictionary<string, NoDupeObject> _keyLookup = new Dictionary<string, NoDupeObject>();
        private NoDupeObject(string p1, int p2, DateTime p3) 
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }
        public string P1 { get; }
        public int P2 { get; }
        public DateTime P3 { get; }
        public static NoDupeObject Get(string p1, int p2, DateTime p3) 
        {
            var key = string.Join("-", p1, p2, p3);
            if (!_keyLookup.TryGetValue(key, out var value))
            {
                value = new NoDupeObject(p1, p2, p3);
                _keyLookup.Add(key, value);
            }
            return value;
        }
    }
