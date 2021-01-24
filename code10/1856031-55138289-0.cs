      using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    var function = "Transport.";
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "searchforserchticketall";
                    command.Parameters.Add(new Npgsql.NpgsqlParameter("source", NpgsqlTypes.NpgsqlDbType.Integer)
                    { Value = source });
                    command.Parameters.Add(new Npgsql.NpgsqlParameter("compagnieid", NpgsqlTypes.NpgsqlDbType.Integer)
                    { Value = compagnieid });
                    if (command.Connection.State == ConnectionState.Closed)
                        command.Connection.Open();
                    var res = command.ExecuteReader();
    				
    			}	
