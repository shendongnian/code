    public struct TriDigit : IComparable, IComparable<TriDigit>, IComparable<int>, IEquatable<TriDigit>, IEquatable<int>
    {
        private readonly int value;
        public TriDigit(int value)
        {
            if (value < 0 || value > 999) throw new ArgumentOutOfRangeException("value");
            this.value = value;
        }
        public override string ToString()
        {
            return value.ToString("000");
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is TriDigit) return ((TriDigit)obj).value == value;
            if (obj is int) return ((int)obj) == value;
            return false;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return -1;
            if(obj is TriDigit) return value.CompareTo(((TriDigit)obj).value);
            if (obj is int) return value.CompareTo((int)obj);
            return -1;
        }
        public override int GetHashCode()
        {
            return value;
        }
        public static explicit operator TriDigit(int value)
        {
            return new TriDigit(value);
        }
        public static implicit operator int(TriDigit value)
        {
            return value.value;
        }
    
        int IComparable<TriDigit>.CompareTo(TriDigit other)
        {
            return value.CompareTo(other.value);
        }
        int IComparable<int>.CompareTo(int other)
        {
            return value.CompareTo(other);
        }
        bool IEquatable<TriDigit>.Equals(TriDigit other)
        {
            return value == other.value;
        }
        bool IEquatable<int>.Equals(int other)
        {
            return value == other;
        }
    }
