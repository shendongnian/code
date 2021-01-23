    public static string BuildSqlNativeConnStr(string server, string database)
    {
      return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;", server, database);
    }
    private void simpleButton1_Click(object sender, EventArgs e)
    {
      const string query = "Insert Into Employees (RepNumber, HireDate) Values (@RepNumber, @HireDate)";
      string connStr = BuildSqlNativeConnStr("apex2006sql", "Leather");
 
      try
      {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
          conn.Open();
          using (SqlCommand cmd = new SqlCommand(query, conn))
          {
            cmd.Parameters.Add(new SqlParameter("@RepNumber", 50));
            cmd.Parameters.Add(new SqlParameter("@HireDate", DateTime.Today));
            cmd.ExecuteNonQuery();
          }
        }
      }
      catch (SqlException)
      {
        System.Diagnostics.Debugger.Break();
      }
    }
