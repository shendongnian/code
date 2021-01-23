    using (OleDbConnection connection = new OleDbConnection(connectionString))
    
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
        
            while (reader.Read())
            {
                // put your logic here to concatenate the strings
                Console.WriteLine(string.Format("{0},{1},{2}",
                      reader["STUDENTNAME"],
                      reader["STUDENTNUMBER"],
                      reader["STUDENTDESCRIPTION"]);    
            }
            reader.Close();
        }
