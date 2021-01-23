    public class StringArrayComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] left, string[] right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }
            if ((left == null) || (right == null))
            {
                return false;
            }
            return left.SequenceEqual(right);
        }
        public int GetHashCode(string[] obj)
        {
            return obj.Aggregate(17, (res, item) => unchecked(res * 23 + item.GetHashCode()));
        }
    }
