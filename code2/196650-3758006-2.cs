    public class CharComparer : IEqualityComparer<string>
    {
        #region IEqualityComparer<string> Members
        public bool Equals(string x, string y)
        {
            if (x == y)
                return true;
            if (x.Length == 3 && y.Length == 3)
            {
                if (x[2] == y[0] && x[0] == y[2])
                    return true;
                if (x[0] == y[2] && x[2] == y[0])
                    return true;
            }
            return false;
        }
        public int GetHashCode(string obj)
        {
            // return 0 to force the Equals to fire (otherwise it won't...!)
            return 0;
        }
        #endregion
    }
