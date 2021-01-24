    switch (oldProactiveSql.InstanceName)
               {
                    case null:
                         try
                         {
                              WriteBackupSp (srv3, oldProactiveSql.DbName, out var storedProcedure);
                              ConnectionToolsUtility.GenerateSqlConnectionString (oldProactiveSql, out var cs);
                              using (SqlConnection connection = new SqlConnection (cs))
                              {
                                   using (SqlCommand command = new SqlCommand (storedProcedure, connection))
                                   {
                                        connection.Open ();
                                        command.ExecuteNonQuery ();
                                        connection.Close ();
                                   }
                              }
                              var execBackup = "EXEC [dbo].[ProactiveDBBackup]\n";
                              using (SqlConnection connection = new SqlConnection (cs))
                              {
                                   using (SqlCommand command = new SqlCommand (execBackup, connection))
                                   {
                                        connection.Open ();
                                        command.ExecuteNonQuery ();
                                        connection.Close ();
                                   }
                              }
                         }
                         catch (Exception e)
                         {
                              Console.WriteLine(e);
                              Console.WriteLine(e.InnerException.Message);
                              throw;
                         }
                         break;
                    default:
                         try { bkpDbFull.SqlBackup(srv2); }
                         catch (Exception e)
                         {
                              Console.WriteLine(e);
                              Console.WriteLine(e.InnerException.Message);
                              throw;
                         }
                         break;
               }
