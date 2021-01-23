    public class StringArrayComparer : IEqualityComparer<string[]>
    {
    
        public bool Equals(string[] x, string[] y)
        {
            if (x==y)
            {
                return true;
            }
    
            if (x== null || y == null)
            {
                return false;
            }
    
            return x.Except(y).Count() == 0;
        }
    
        public int GetHashCode(string[] obj)
        {
            // there may be better implementations of GetHashCode
            int sum = obj.Sum(s => s.GetHashCode());
            return sum.GetHashCode();
        }
    }
