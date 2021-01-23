    public static class HelperFunctions
        {
            public static void Map<T>(this IEnumerable<T> source, Action<T> func)
            {
                foreach (T i in source)
                    func(i);
            }
    
            public static DataTable ToDataTable<T>(this IEnumerable<T> source)
            {
                var dt = new DataTable();
                var properties = typeof(T).GetProperties();
                dt.Columns.AddRange(properties.Select(x => new DataColumn(x.Name, x.PropertyType)).ToArray());
                source.Select(x => dt.NewRow().ItemArray = properties.Select(y => y.GetValue(x, null)).ToArray()).Map(x => dt.Rows.Add(x));
                return dt;
            }
        }
