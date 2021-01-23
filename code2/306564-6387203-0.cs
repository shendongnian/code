     public partial class MyTableTableAdapter(OleDbConnection connection)
     {
          if (connection == null)
              throw new ArgumentNullException("connection");
          base.Connection = connection;
     }
     public partial class MyTableTableAdapter(string connectionString)
     {
          base.Connection = new OleDbConnection(connectionString);
     }
