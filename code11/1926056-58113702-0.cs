             using (var connection = new SqlConnection(@"connection string..."))
             {
                connection.Open();
                var command = new SqlCommand("Proc_SelectDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("id", SqlDbType.Int);
                command.Parameters["id"].Value = 234;
                var name = command.Parameters.Add("Name", SqlDbType.VarChar, 50);
                name.Direction = ParameterDirection.Output;
                var rollNo = command.Parameters.Add("RollNo", SqlDbType.VarChar, 50);
                rollNo.Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                Console.WriteLine(name.Value);
                Console.WriteLine(rollNo.Value);
    
                }
