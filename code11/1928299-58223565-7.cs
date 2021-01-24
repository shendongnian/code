    public List<string> GetClientNames(string email)
    {
      var constr = ConfigurationManager.ConnectionStrings["myConnectionString"];
      var sql = "SELECT Clients FROM users WHERE Email=@email";
    
      var factory = DbProviderFactories.GetFactory(constr.Provider);
      using (var conn = factory.CreateConnection {ConnectionString = constr.ConnectionString})
      using (var cmd = conn.CreateCommand {CommandText = sql})
      {
        var param = cmd.CreateParameter();
        param.ParameterName="@email";
        param.Value=email;
        cmd.Parameters.Add(param);
        conn.Open();
        return ((string)cmd.ExecuteScalar()).Split('|').ToList();
      }
    }
