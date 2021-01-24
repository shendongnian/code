    public class Key : IEquatable<Key>
    {
        private Tuple<int, int> _tuple;
        public Key(int a, int b)
        {
            _tuple = new Tuple<int, int>(a, b);
        }
        public bool Equals(Key other)
        {
            return (this.GetHashCode() == other.GetHashCode());
        }
        public override int GetHashCode()
        {
            return _tuple.GetHashCode();
        }
    }
