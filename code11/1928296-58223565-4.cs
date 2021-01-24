    public List<string> GetClientNames(string email)
    {
      var constr=ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
      var sql = "SELECT Clients FROM users WHERE Email=@email";
    
      using (var conn = new SqlConnection(constr))
      using (var cmd = new SqlCommand(sql, conn))
      {
        cmd.Parameters.Add("@email",SqlDbType.VarChar).Value = email;
        conn.Open();
        return ((string)cmd.ExecuteScalar()).Split('|').ToList();
      }
    }
