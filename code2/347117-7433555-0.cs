    using (OracleConnection oracleConnection = new OracleConnection(connection))
                    {
                        oracleConnection.Open();
                        OracleCommand Command = new OracleCommand();
                        Command.Connection = oracleConnection;
                        Command.CommandType = CommandType.Text;
                        status = "A";
                        foreach (var memberID in MemberIDs)
                        {
                            sqlStatement = " UPDATE " + " ourdbtable" + " Set userstatus = '" + status + "' WHERE " + "memberid= " + memberID;
                            // command
                            Command.CommandText = sqlStatement;
                            Command.ExecuteNonQuery();
                        }
                    }
