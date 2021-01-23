    struct Permutation : IEquatable<Permutation>, IComparable<Permutation>
    {
        public IComparable Software1 { get; set; }
        public IComparable Software2 { get; set; }
        public IComparable Software3 { get; set; }
        public bool Equals(Permutation other)
        {
            return Equals(other.Software1, Software1) && Equals(other.Software2, Software2) && Equals(other.Software3, Software3);
        }
        public int CompareTo(Permutation other)
        {
            int cmp = 0;
            if (0 == cmp) cmp = other.Software1.CompareTo(Software1);
            if (0 == cmp) cmp = other.Software2.CompareTo(Software2);
            if (0 == cmp) cmp = other.Software3.CompareTo(Software3);
            return cmp;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Permutation)) return false;
            return Equals((Permutation)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Software1 != null ? Software1.GetHashCode() : 0);
                result = (result * 397) ^ (Software2 != null ? Software2.GetHashCode() : 0);
                result = (result * 397) ^ (Software3 != null ? Software3.GetHashCode() : 0);
                return result;
            }
        }
        public static bool operator ==(Permutation left, Permutation right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Permutation left, Permutation right)
        {
            return !left.Equals(right);
        }
    }
