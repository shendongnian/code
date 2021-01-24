    public class Key
    {
        private readonly Tuple<int, int> _tuple;
        public Key(int item1, int item2)
        {
            _tuple = new Tuple<int, int>(item1, item2);
        }
        public override bool Equals(object obj)
        {
            var other = obj as Key;
            return _tuple.Item1 == other._tuple.Item1 && _tuple.Item2 == other._tuple.Item2;
        }
        public override int GetHashCode()
        {
            return _tuple.Item1.GetHashCode() ^ _tuple.Item2.GetHashCode();
        }
    }
