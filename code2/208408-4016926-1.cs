    using (OleDBConnection connection = new OleDBConnection(connectiongString)) {
        if (connection.State != ConnectionState.Open)
            connection.Open();
        string sql = "INSERT INTO Student (Id, Name) VALUES (@idParameter, @nameParameter)"
        using (OleDBCommand command = connection.CreateCommand()) {
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            OleDBParameter idParameter = command.CreateParameter()
            idParameter.DbType = System.Int32;
            idParameter.Direction = Parameterdirection.Input;
            idParameter.Name = "@idParameter";
            idParameter.Value = studentId; // Where studentId is an int variable that holds your parsed TextBox.Text property value.
            OleDBParameter nameParameter = command.CreateParameter()
            // Do the same as you did above for the nameParameter.
     
            try {
                command.ExecuteNonQuery()
            } finally {
                command.Dispose();
                connection.Dispose();
            }
        }
    }
