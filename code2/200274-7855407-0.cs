    const string connectionString = @"server=.\sqlexpress;database=adventureworkslt;integrated security=true";
    const bool useMARS = false;
    using (var objConn = new System.Data.SqlClient.SqlConnection(connectionString + (useMARS ? ";MultipleActiveResultSets=True" : String.Empty)))
    using (var objInsertConn = useMARS ? null : new System.Data.SqlClient.SqlConnection(connectionString))
    {
     objConn.Open();
     if (objInsertConn != null)
     {
      objInsertConn.Open();
     }
    
     using (var testCmd = new System.Data.SqlClient.SqlCommand())
     {
      testCmd.Connection = objConn;
      testCmd.CommandText = @"if not exists(select 1 from information_schema.tables where table_name = 'sourcetable')
                              begin
                               create table sourcetable (field1 int, field2 varchar(5))
                               insert into sourcetable values (1, 'one')
                               create table tablename (field1 int, field2 varchar(5))
                              end";
      testCmd.ExecuteNonQuery();
     }
    
     using (var objCommand = new System.Data.SqlClient.SqlCommand("SELECT field1, field2 FROM sourcetable", objConn))
     using (var objDataReader = objCommand.ExecuteReader())
     using (var objInsertCommand = new System.Data.SqlClient.SqlCommand("INSERT INTO tablename (field1, field2) VALUES (3, @field2)", objInsertConn ?? objConn))
     {
      objInsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("field2", String.Empty));
      while (objDataReader.Read())
      {
       objInsertCommand.Parameters[0].Value = objDataReader[0];
       objInsertCommand.ExecuteNonQuery();
      }
     }
    }
