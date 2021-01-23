    string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\temp;Extended Properties=dBase IV";
    
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    using (OleDbCommand command = connection.CreateCommand())
    {
        connection.Open();
    
        command.CommandText = "CREATE TABLE Test (Id Integer, Changed Double, Name Text)";
        command.ExecuteNonQuery();
    }
