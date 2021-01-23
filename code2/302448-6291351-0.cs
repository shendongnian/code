    public static DataTable CreateEmptyDataTable(Type myType)
    {
        DataTable dt = new DataTable();
    
        foreach (PropertyInfo info in myType.GetProperties())
        {
            dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
        }
        
        return dt;
    }
