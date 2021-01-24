    public sealed class IntArrayKey: IEquatable<IntArrayKey>
    {
        public IntArrayKey(IEnumerable<int> sequence)
        {
            _array    = sequence.ToArray();
            _hashCode = hashCode();
            Array = new ReadOnlyCollection<int>(_array);
        }
        public bool Equals(IntArrayKey other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return _hashCode == other._hashCode && equals(other.Array);
        }
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is IntArrayKey other && Equals(other);
        }
        public static bool operator == (IntArrayKey left, IntArrayKey right)
        {
            return Equals(left, right);
        }
        public static bool operator != (IntArrayKey left, IntArrayKey right)
        {
            return !Equals(left, right);
        }
        public IReadOnlyList<int> Array { get; }
        public override int GetHashCode()
        {
            return _hashCode;
        }
        bool equals(IReadOnlyList<int> other) // other cannot be null.
        {
            if (_array.Length != other.Count)
                return false;
            for (int i = 0; i < _array.Length; ++i)
                if (_array[i] != other[i])
                    return false;
            return true;
        }
        int hashCode()
        {
            int result = 17;
            unchecked
            {
                foreach (var i in _array)
                {
                    result = result * 23 + i;
                }
            }
            return result;
        }
        readonly int   _hashCode;
        readonly int[] _array;
    }
