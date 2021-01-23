    using System.Data;
    
    public static class DataTableExtensions
    {
        public static IEnumerable<DataRow> Intersect(this DataTable table, DataTable other)
        {
            return table.AsEnumerable().Intersect(other.AsEnumerable());
        }
    
        public static IEnumerable<DataRow> Intersect(this DataTable table, DataTable other, IEqualityComparer<DataRow> comparer)
        {
            return table.AsEnumerable().Intersect(other.AsEnumerable(), comparer);
        }
    }
