        string dbfDirectory = @"c:\";
        string connectionString = "Provider=VFPOLEDB;Data Source=" + dbfDirectory;
        using (OleDbConnection connection = new OleDbConnection(connectionString)) {
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "create table Customer(CustId int, CustName v(250))";
            command.ExecuteNonQuery();
            connection.Close();
        }
