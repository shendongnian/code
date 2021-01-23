    using (var command = connection.CreateCommand())
                         {
                             command.Transaction = transaction;
                             command.CommandType = CommandType.TableDirect;
                             command.CommandText = TABLE_NAME_IN_SQL;
    
                             using (var rs = command.ExecuteResultSet(ResultSetOptions.Updatable))
                             {
                                 var rec = rs.CreateRecord();
                                 rec.SetInt32(0, value0); // the index represents the column numbering
                                 rec.SetString(1, value1);
                                 rec.SetInt32(2, value2);
                                 rs.Insert(rec);
                             }
    }
