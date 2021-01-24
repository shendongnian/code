    class Key : IEquatable<Key>
    {
        private readonly Tuple<int, int> tuple;
        public Key(int a, int b)
        {
            tuple = new Tuple<int, int>(a, b);
        }
        public bool Equals(Key other)
        {
            return other != null && 
                tuple.Item1 == other.tuple.Item1 && 
                tuple.Item2 == other.tuple.Item2;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Key);
        }
        public override int GetHashCode()
        {
            return tuple.Item1.GetHashCode() ^ tuple.Item2.GetHashCode();
        }
    }
