        public static void InsertModelValueInBulk(DataSet employeData, int clsaId, int batchSize)
        {
            string[] insertStatement = new string[batchSize];
            using (var connection = GetOdbcConnection())
            {
                connection.Open();
                var tran = connection.BeginTransaction();
                try
                {
                    int j = 0;
                    for (int i = 0; i < employeData.Tables[0].Rows.Count; i++)
                    {
                        var row = employeData.Tables[0].Rows[i];
                        var insertItem = string.Format(@"select '{0}',{1}", row["name"], Convert.ToInt32(row["ID"]);
                        insertStatement[j] = insertItem;
                        if (j % (batchSize-1) == 0 && j > 0)
                        {
                            var finalQuery = @" INSERT INTO employee (id, name)
                                             " + String.Join(" union ", insertStatement);
                            using (var cmd = new OdbcCommand(finalQuery, connection, tran))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            j = 0;
                            continue;
                        }
                        else
                        {
                            j = j + 1;
                        }
                    }
                    if (j > 0)
                    {
                        var finalQuery = @"INSERT INTO employee (id, name)
                                         " + String.Join(" union ", insertStatement,0,j-1);
                        using (var cmd = new OdbcCommand(finalQuery, connection, tran))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
