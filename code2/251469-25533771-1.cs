    public static class DataTableExtensions
    {
        public static IEnumerable<DataColumn> GetColumns(this DataTable source)
        {
            return source.Columns.AsEnumerable();
        }
    }
