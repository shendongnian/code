    List<DataRow> results = lst1.Union(lst2, new RowComparer()).ToList();
    public class RowComparer : IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow x, DataRow y) {
            return x.Field<int>("ID") == y.Field<int>("ID");
        }
    
        public int GetHashCode(DataRow obj) {
            return obj.Field<int>("ID").GetHashCode();
        }
    }
