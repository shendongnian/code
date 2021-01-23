    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    namespace ConsoleApplication3 {
      class Program {
        private const string ConnectionStringToFile = @"Data Source=.\SqlExpress;Integrated Security=True;AttachDbFileName={0};User Instance=True";
        private const string ConnectionStringToTempDb = @"Data Source=.\SqlExpress;Initial Catalog=TempDb;Integrated Security=True;User Instance=True;";
        private const string CreateDbSql = "CREATE DATABASE {0} ON PRIMARY (NAME='{0}', FILENAME='{1}');";
        private const string DetachDbSql = "EXEC sp_detach_db '{0}', 'true';";
        private static SqlConnection GetConnection(string connectionString) {
          var conn = new SqlConnection(connectionString);
          Debug.WriteLine("Created", "Connection");
          Debug.Indent();
          conn.StateChange += ConnectionStateChange;
          conn.InfoMessage += ConnectionInfoMessage;
          conn.Disposed += ConnectionDisposed;
          return conn;
        }
        private static void ConnectionDisposed(object sender, EventArgs e) {
          SqlConnection conn = (SqlConnection)sender;
          conn.StateChange -= ConnectionStateChange;
          conn.InfoMessage += ConnectionInfoMessage;
          conn.Disposed += ConnectionDisposed;
          Debug.Unindent();
          Debug.WriteLine("Disposed", "Connection");
        }
        private static void ConnectionInfoMessage(object sender, SqlInfoMessageEventArgs e) {  
          Debug.WriteLine("InfoMessage: " + e.Message, "Connection");
        }
        private static void ConnectionStateChange(object sender, System.Data.StateChangeEventArgs e) {
          Debug.WriteLine("StateChange: from " + e.OriginalState + " to " + e.CurrentState, "Connection");
        }
        static void Main() {
          const string DbName = "temp";
          const string DbPath = "c:\\temp.mdf";
          const string DbLogFile = "c:\\temp_log.ldf";
          using (var conn = GetConnection(ConnectionStringToTempDb)) {
            conn.Open();
            using (var command = conn.CreateCommand()) {
              command.CommandText = string.Format(CreateDbSql, DbName, DbPath);
              command.ExecuteNonQuery();
              command.CommandText = string.Format(DetachDbSql, DbName);
              Debug.WriteLine("Detach result: " + command.ExecuteScalar(), "Database"); 
            }
          }
          using (var conn = GetConnection(string.Format(ConnectionStringToFile, DbPath))) {
            conn.Open();
            using (var command = conn.CreateCommand()) {
              command.CommandText = "PRINT 'Successfully connected to database.'";
              command.ExecuteNonQuery();
              command.CommandText = "CREATE TABLE temp (temp int)";
              command.ExecuteNonQuery();
              command.CommandText = "INSERT temp VALUES (1);";
              command.ExecuteNonQuery();
            }
            SqlConnection.ClearPool(conn);
          }
          // SqlExpress takes 300ms to go idle:
          // http://blogs.msdn.com/b/sqlexpress/archive/2008/02/22/sql-express-behaviors-idle-time-resources-usage-auto-close-and-user-instances.aspx
          Thread.Sleep(500); // wait for 500ms just in case (seems to work with 300 though).
          if (File.Exists(DbPath)) File.Delete(DbPath);
          if (File.Exists(DbLogFile)) File.Delete(DbLogFile);
        }
      }
    }
