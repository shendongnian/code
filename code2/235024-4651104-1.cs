    public class NameComparer : IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow left, DataRow right)
        {
            return left.Field<string>("Name").Equals(right.Field<string>("Name"));
        }
     
        public int GetHashCode(DataRow obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
