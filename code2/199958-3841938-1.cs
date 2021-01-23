     string connectionString = @"Provider=VFPOLEDB.1;Data Source=C:\YourDirectory\"; 
     
        using (OleDbConnection connection = new OleDbConnection(connectionString)) 
        { 
            using (OleDbCommand scriptCommand = connection.CreateCommand()) 
            { 
                connection.Open(); 
     
                string vfpScript = @"USE TestDBF 
                                     COPY TO OldDBaseFormatFile TYPE Fox2x 
                                    USE"; 
     
                scriptCommand.CommandType = CommandType.StoredProcedure; 
                scriptCommand.CommandText = "ExecScript"; 
                scriptCommand.Parameters.Add("myScript", OleDbType.Char).Value = vfpScript; 
                scriptCommand.ExecuteNonQuery(); 
            } 
        } 
