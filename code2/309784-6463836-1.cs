       string connectionString = ConfigurationManager.ConnectionStrings["fileStreamDB"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            //Get the PathName of the File from the database
            command.CommandText = "SELECT Picture.PathName(), "
            + "GET_FILESTREAM_TRANSACTION_CONTEXT() FROM Product WHERE ProductID = 1";
            SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            command.Transaction = transaction;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string path = reader.GetString(0);
                    SqlFileStream stream = new SqlFileStream(path,
                        (byte[])reader.GetValue(1), FileAccess.Write,
                        FileOptions.SequentialScan, 0);                        
                    string contents = txtInput.Text;                        
                    stream.Write((System.Text.Encoding.ASCII.GetBytes(contents)), 0, contents.Length);
                    stream.Close();
                }
            }
            transaction.Commit();
        }
