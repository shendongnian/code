    public class idCompare : IEqualityComparer<Collect>
    {
        public bool Equals(Collect x, Collect y)
        {
            return Equals(x.id, y.id);
        }
        public int GetHashCode(Collect obj)
        {
            return obj.GetHashCode();
        }
    }
    ....
  
    list.Distinct(new idCompare());
