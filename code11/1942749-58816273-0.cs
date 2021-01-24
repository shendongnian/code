    public sealed class StringListEqualityComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<string> strings)
        {
            int hash = 17;
            foreach (var s in strings)
            {
                unchecked
                {
                    hash = hash * 23 + s?.GetHashCode() ?? 0;
                }
            }
            return hash;
        }
    }
