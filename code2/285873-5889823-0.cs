    public static class ExtensionMethods
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            DataTable table = new DataTable();
            var properties = typeof(T).GetProperties();
            foreach (var propertyInfo in properties)
            {                
                table.Columns.Add(propertyInfo.Name, typeof(object));
            }
            foreach (var item in items)
            {
                var row = properties.Select(p => NormalizeObject(p.GetValue(item, null))).ToArray();                                
                table.Rows.Add(row);
            }
            return table;
        }
        
        private static object NormalizeObject(object value)
        {
            Binary bin = value as Binary;
            if (bin != null)
            {
                return bin.ToArray();
            }
            XElement element = value as XElement;
            if (element != null)
            {
                return element.ToString();
            }
            return value;
        }
    }
