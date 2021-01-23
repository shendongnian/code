    private SqlParameter GenerateTypedParameter(string name, object typedParameter)
    {
        DataTable dt = new DataTable();
        var properties = typedParameter.GetType().GetProperties().ToList();
        properties.ForEach(p =>
        {
            dt.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
        });
        var row = dt.NewRow();
        properties.ForEach(p => { row[p.Name] = (p.GetValue(typedParameter) ?? DBNull.Value); });
        dt.Rows.Add(row);
        return new SqlParameter
        {
            Direction = ParameterDirection.Input,
            ParameterName = name,
            Value = dt,
            SqlDbType = SqlDbType.Structured
        };
    }
