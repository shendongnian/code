    string connectionString ="yourConnectionString"
    using (DbConnection conn = new OdbcConnection(connectionString))
    using (DbCommand cmd = conn.CreateCommand())
    {
      cmd.CommandText = "INSERT INTO Animals(home) VALUES (@animal)";
      DbParameter p = cmd.CreateParameter();
      p.ParameterName = "@animal";
      cmd.CommandType = CommandType.Text;
      conn.Open();
      using (DbTransaction tran = conn.BeginTransaction())
     {
         cmd.Transaction = tran;
         try
         {
             foreach (string line in MyRichTextBox.Lines)
             {
                p.Value = line;
                cmd.ExecuteNonQuery();
             }
             tran.Commit();
             conn.Close();
         }
         catch (Exception e)
         {
             tran.Rollback();
            throw(e);
         }
     }
