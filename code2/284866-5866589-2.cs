    public DataTable GetDataForProject(string projectName)
    {
       string connStr = "Data Source=Silverage-6\\SQLSERVER2005;Initial Catalog=emp;Integrated Security=SSPI";
       string queryStmt = 
          "SELECT project, iteration, activity, description, status, hour " + 
          "FROM dbo.timeday " + 
          "WHERE project = @project";
       DataTable resultTable = new DataTable();
       using(SqlConnection conn = new SqlConnection())
       using(SqlCommand _cmd = new SqlCommand(queryStmt, conn))
       {
          _cmd.Parameters.Add("@Project", SqlDbType.VarChar, 100);
          _cmd.Parameters["@Project"].Value = projectName;
          SqlDataAdapter dap = new SqlDataAdapter(_cmd);
          dap.Fill(resultTable);
       }
       return resultTable;
    }
