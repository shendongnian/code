    public class MyEqualityComparer : IEqualityComparer<IEnumerable<int>>
    {
        public bool Equals(IEnumerable<int> x, IEnumerable<int> y)
        {
            return x.OrderBy(el1 => el1).SequenceEqual(y.OrderBy(el2 => el2));
        }
    
        public int GetHashCode(IEnumerable<int> elements)
        {
            int hash = 0;
            foreach (var el in elements)
            {
                hash = hash ^ el.GetHashCode();
            }
            return hash;
        }
    }
