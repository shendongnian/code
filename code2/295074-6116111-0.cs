    var connection = new System.Data.SqlClient.SqlConnection(connection);
                var command = connection.CreateCommand();
                command.CommandText = "procedureName";
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("paramName", "output"));
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
