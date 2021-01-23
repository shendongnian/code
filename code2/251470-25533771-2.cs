    public static class DataColumnCollectionExtensions
    {
        public static IEnumerable<DataColumn> AsEnumerable(this DataColumnCollection source)
        {
            return source.Cast<DataColumn>();
        }
    }
