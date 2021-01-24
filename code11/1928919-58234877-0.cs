            using (OracleConnection oracleConnection = new OracleConnection("Data Source=...."))
            {
                string query = @"INSERT INTO mytable (COL1, COL2) VALUES (:col1, :col2)";
                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = dt.Rows.Count;
                    command.Parameters.Add(":col1", OracleDbType.Int32, dt.AsEnumerable().Select(r => r.Field<Int32>("col1")).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":col2", OracleDbType.Date, dt.AsEnumerable().Select(r => r.Field<DateTime>("col2")).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                }
            }
