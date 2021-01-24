    public static class DataTableExtensions
    {
        public static string ToJson(this DataTable dataTable)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException(nameof(dataTable));
            }
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dataTable.Rows)
            {
                Dictionary<string, object> item = new Dictionary<string, object>();
                foreach(DataColumn column in dataTable.Columns)
                {
                    item.Add(column.ColumnName, Convert.IsDBNull(row[column]) ? null : row[column]);
                }
                list.Add(item);
            }
            return list.SerializeObject();
        }
    }
