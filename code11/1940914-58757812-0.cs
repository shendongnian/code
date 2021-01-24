            public Dictionary<string, TestModel> GetTestModelDictionary(string id, string subject, string UseYN, string createDate1, string createDate2)
            {
                Dictionary<string, TestModel> dict = new Dictionary<string, TestModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_connection))
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"SELECT ID, Subject,  CreateDate, UpdateDate FROM Test";
                    command.Parameters.Add(new SQLiteParameter(@"ID", DbType.String) { Value = id });
                    command.Parameters.Add(new SQLiteParameter(@"Subject", DbType.String) { Value = subject });
                    command.Parameters.Add(new SQLiteParameter(@"CreateDate1", DbType.String) { Value = createDate1 });
                    command.Parameters.Add(new SQLiteParameter(@"CreateDate2", DbType.String) { Value = createDate2 });
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TestModel item = new TestModel();
                        item.ID = reader["ID"].ToString();
                        item.Subject = reader["Subject"].ToString();
                        item.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                        item.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                        dict.Add(item.ID, item);
                    }
                }
                return dict;
            }
