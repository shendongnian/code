    public Class1(DataRow row)
    {
        var type = typeof(Class1);
        foreach(var col in row.Table.Columns)
        {
            var property = type.GetProperty(col.ColumnName);
            property.SetValue(this, row.Item(col), null);
        }
    }
