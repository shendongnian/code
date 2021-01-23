    using (DbCommand command = oledbConn.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO [Sheet2$] (custid, Fullname, Salutation) VALUES (" + CustID + ",\"John Smith\",\"John\")";
                            //connection.Open();
                            command.ExecuteNonQuery();
                        }
