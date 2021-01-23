    string connectionString = @"Provider=VFPOLEDB.1;Data Source=D:\temp";
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    using (OleDbCommand command = connection.CreateCommand())
    {
        connection.Open();
    
        OleDbParameter script = new OleDbParameter("script", @"CREATE TABLE Test (Id I, Changed D, Name C(100))");
    
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "ExecScript";
        command.Parameters.Add(script);
        command.ExecuteNonQuery();
    }
