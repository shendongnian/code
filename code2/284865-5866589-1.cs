    string connStr = "Data Source=Silverage-6\\SQLSERVER2005;Initial Catalog=emp;Integrated Security=SSPI";
    string queryStmt = 
       "INSERT INTO dbo.timeday(project, iteration, activity, description, status, hour) " + 
       "VALUES(@Project, @Iteration, @Activity, @Description, @Status, @Hour)";
    using(SqlConnection conn = new SqlConnection())
    using(SqlCommand _cmd = new SqlCommand(queryStmt, conn))
    {
       _cmd.Parameters.Add("@Project", SqlDbType.VarChar, 100);
       _cmd.Parameters["@Project"].Value = this.name1.SelectedValue.Trim();
       // add other parameters the same way....
       conn.Open();
       int result = _cmd.ExecuteNonQuery();
       conn.Close();
    }
