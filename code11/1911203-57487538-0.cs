    private static ExpandoObject GetItem(DataRow dr)
    {
        IDictionary<string, object> obj = new ExpandoObject();
        try
        {
            foreach (DataColumn column in dr.Table.Columns)
            {
                if(col.DataType == typeof(string))
                {
                   obj.Add(col.ColumnName, dr.IsNull(column.ColumnName) ? "" : dr[column.ColumnName], null);
                }
                ....
             }
        }
        catch(Exception ex)
        {
            string msg = ex.Message;
        }
        return obj as ExpandoObject;
    }
