    private class NestedPropertyInfo
    {
        public PropertyInfo Parent { get; set; }
        public PropertyInfo Child { get; set; }
        public string Name { get { return Parent.Name + "_" + Child.Name; } }
    }
    private DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
    {
        DataTable dtReturn = new DataTable();
        NestedPropertyInfo[] columns = null;
        if (varlist == null) return dtReturn;
        foreach (T rec in varlist)
        {
            if (columns == null)
            {
                columns = (
                    from p1 in rec.GetType().GetProperties()
                    from p2 in p1.PropertyType.GetProperties()
                    select new NestedPropertyInfo { Parent = p1, Child = p2 }
                    ).ToArray();
                foreach (var column in columns)
                {
                    var colType = column.Child.PropertyType;
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }
                    dtReturn.Columns.Add(new DataColumn(column.Name, colType));
                }
            }
            DataRow dr = dtReturn.NewRow();
            foreach (var column in columns)
            {
                var parentValue = column.Parent.GetValue(rec, null);
                var childValue = parentValue == null ? null : column.Child.GetValue(parentValue, null);
                dr[column.Name] = childValue ?? DBNull.Value;
            }
            dtReturn.Rows.Add(dr);
        }
        return dtReturn;
    }
