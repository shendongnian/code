    private class ShortestSubStringComparer : IComparer<string>, IEqualityComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null) return (y == null) ? 0 : -1;
            if (y == null) return 1;
            Debug.Assert(x != null && y != null);
            if (this.Equals(x, y)) return x.Length.CompareTo(y.Length);
            return StringComparer.CurrentCulture.Compare(x, y);
        }
        public bool Equals(string x, string y)
        {
            if (x == null) return y == null;
            if (x.StartsWith(y)) return true;
            if (y != null && y.StartsWith(x)) return true;
            return false;
        }
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
