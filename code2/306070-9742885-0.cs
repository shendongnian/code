                    var commandData = new SqlCommandData
                                          {
                                              Command = new SqlCommand {Connection = connection}
                                          };
                    connection.Open();
                    // ELIDED - other initialization of command - used to send the results of calculation back to DB
                    commandData.AsyncResult = commandData.Command.BeginExecuteNonQuery();
