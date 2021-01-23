    public static void AddWithValue_Tvp_Int(this SqlParameterCollection paramCollection, string parameterName, List<int> data)
    {
       var p = paramCollection.Add(parameterName, SqlDbType.Structured);
       p.TypeName = "dbo.tvp_Int";
       DataTable _dt = new DataTable() {Columns = {"Value"}};
       data.ForEach(value => _dt.Rows.Add(value));
       p.Value = _dt;
    }
