     public static void MessageEventHandler( object sender, SqlInfoMessageEventArgs e ) {
             foreach( SqlError error in e.Errors ) {
                Console.WriteLine("problem with sql: "+error);
                throw new Exception("problem with sql: "+error);
             }
          }
          public static int executeSQLUpdate(string database, string command) {
             SqlConnection connection = null;
             SqlCommand sqlcommand = null;
             int rows = -1;
             try {
                connection = getConnection(database);
                connection.InfoMessage += new SqlInfoMessageEventHandler( MessageEventHandler );
                sqlcommand = connection.CreateCommand();
                sqlcommand.CommandText = command;
                connection.Open();
                rows = sqlcommand.ExecuteNonQuery();
              } catch(Exception e) {
                Console.Write("executeSQLUpdate: problem with command:"+command+"e="+e);
                Console.Out.Flush();
                throw new Exception("executeSQLUpdate: problem with command:"+command,e);
             } finally {
                if(connection != null) { connection.Close(); }
             } 
             return rows;
          }
