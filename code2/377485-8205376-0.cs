    public class idCompare : IEqualityComparer<data>
    {
        public bool Equals(data x, data y)
        {
            return Equals(x.id, y.id);
        }
        public int GetHashCode(data obj)
        {
            return obj.GetHashCode();
        }
    }
    ....
  
    list.Distinct();
