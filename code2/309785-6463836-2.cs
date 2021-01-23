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
                            (byte[])reader.GetValue(1),FileAccess.Read,FileOptions.SequentialScan, 0);                        
                        lstResults.Items.Clear();
                        int length = (int) stream.Length;
                        byte[] contents = new byte[length];
                        stream.Read(contents,0,length);                     
                        string results = System.Text.Encoding.ASCII.GetString(contents);
                        lstResults.Items.Add(results);
                        stream.Close();
                    }
                }
                transaction.Commit();
            }
