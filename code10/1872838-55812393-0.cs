    public static object DeployAccountTypes()
    {
      using (SqlConnection cfgConn = Connection.GetConnection(NamedConnection.Configuration))
      using (SqlConnection valConn = Connection.GetConnection(NamedConnection.Validation))
      using (SqlCommand cmd = new SqlCommand("SELECT *, '' as Name FROM tcRAPIDAccountTypes (NOLOCK) ORDER BY EvaluationOrder", cfgConn))
      using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM tcRAPIDLoadAccountTypes (NOLOCK)", valConn))
      {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable cfgData = new DataTable();
        da.Fill(cfgData);
        da = new SqlDataAdapter(cmd1);
        DataTable valData = new DataTable();
        da.Fill(valData);
        var results = (from cfg in cfgData.AsEnumerable()
            join val in valData.AsEnumerable() on cfg.Field<int>("AccountTypeId") equals val.Field<int>("Id")
            select new { cfg = cfg, val = val })
            .ToList();
      }
    }
