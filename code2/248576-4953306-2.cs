    public static DataTable ToDataTable<T>(this IEnumerable<T> source)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();
       
        DataTable output = new DataTable();
    
        foreach(var prop in properties)
        {
            output.Columns.Add(prop.Name, prop.PropertyType);
        }
    
        foreach(var item in source)
        {
            DataRow row = output.NewRow();
    
            foreach(var prop in properties)
            {
                row[prop.Name] = prop.GetValue(item, null);
            }
    
            output.Rows.Add(row);
        }
    
        return output;
    }
