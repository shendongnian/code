    using (var connection = new SqlConnection("....{connection string}..."))
            using (var selectCommand = connection.CreateCommand())
            {
                selectCommand.CommandText = "SELECT whatever FROM wherever";
                //...command parameters setup here if necessary
                using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        //process data here
                        int whateverId = (int)reader["IdColumn"];
                        string whateverName = (string)reader["NameColumn"];
                        
                        //and so on, you get the idea...
                    }
                }
            }
