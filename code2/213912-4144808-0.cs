    public static DataTable ToDataTable<T>(IEnumerable<T> items)
    {
        var table = CreateDataTableForPropertiesOfType<T>();
        PropertyInfo[] piT = typeof(T).GetProperties();
        foreach (var item in items)
        {
            var dr = table.NewRow();
            for (int property = 0; property < table.Columns.Count; property++)
            {
                if (piT[property].CanRead)
                {
                    var value = piT[property].GetValue(item, null);
                    if (piT[property].PropertyType.IsGenericType)
                    {
                        if (value == null)
                        {
                            dr[property] = DBNull.Value;
                        }
                        else
                        {
                            dr[property] = piT[property].GetValue(item, null);
                        }
                    }
                    else
                    {
                        dr[property] = piT[property].GetValue(item, null);
                    }
                }
            }
            table.Rows.Add(dr);
        }
        return table;
    }
    public static DataTable CreateDataTableForPropertiesOfType<T>()
    {
        DataTable dt = new DataTable();
        PropertyInfo[] piT = typeof(T).GetProperties();
        foreach (PropertyInfo pi in piT)
        {
            Type propertyType = null;
            if (pi.PropertyType.IsGenericType)
            {
                propertyType = pi.PropertyType.GetGenericArguments()[0];
            }
            else
            {
                propertyType = pi.PropertyType;
            }
            //create a datacolumn for each property
            DataColumn dc = new DataColumn(pi.Name, propertyType);
            if (pi.CanRead)
            {
                dt.Columns.Add(dc);
            }
        }
        return dt;
    }
