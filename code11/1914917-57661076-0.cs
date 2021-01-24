    public class ArrayKeyComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            return x == null || y == null 
                ? x == null && y == null 
                : x.SequenceEqual(y);
        }
    
        public int GetHashCode(int[] obj)
        {
            var seed = 0;
    
            if(obj != null)
                foreach (int i in obj)
                    seed %= i.GetHashCode();
    
            return seed;
        }
    }
