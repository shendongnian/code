    class ArrayComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            if (x.Length != y.Length)
                return false;
                
            var left = x.OrderBy(s => s).ToArray();
            var right = y.OrderBy(s => s).ToArray();
            
            for (int index = 0; index < x.Length; index++)
            {
                if (left[index] == right[index])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            
            return true;
        }
        
        public int GetHashCode(string[] obj)
        {
            int hash = 23;
            foreach (var element in obj.OrderBy(s => s))
            {
                hash = hash * 37 + element.GetHashCode();
            }
            
            return hash;
        }
    }
