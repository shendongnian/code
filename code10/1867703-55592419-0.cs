        public int InsertItem(string item1, string item2, string item3)
        {
            using (var connection = CreateDBConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    INSERT dbo.TableName(item1, item2, item3)
                    OUTPUT Inserted.Id
                    VALUES (@item1, @item2, @item3)";
                command.Parameters.Add(new SqlParameter("@item1", item1));
                command.Parameters.Add(new SqlParameter("@item2", item2));
                command.Parameters.Add(new SqlParameter("@item3", item3));
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }
