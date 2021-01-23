    foreach (DataColumn col in dt.Columns)
    {
       PropertyInfo prop = emp.GetType().GetProperty(col.ColumnName);
       prop.SetValue(emp, row[col.ColumnName], null);
    }
