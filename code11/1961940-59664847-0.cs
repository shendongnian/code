    public class IntArrayComparer : IEqualityComparer<string[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            var shared = x.Intersect(y);
            return x.Length == y.Length && shared.Count() == x.Length;;
        }
    
        public int GetHashCode(int[] obj)
        {
            int hashCode=obj.Length;
            for(int i=0;i<obj.Length;++i)
            {
              hashCode=unchecked(hashCode*314159 +obj[i]);
            }
            return hashCode;
        }
    }
