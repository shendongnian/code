     public partial class MyTableTableAdapter
     {
         public MyTableTableAdapter(OleDbConnection connection)
         {
              if (connection == null)
                  throw new ArgumentNullException("connection");
              base.Connection = connection;
         }
         public MyTableTableAdapter(string connectionString)
         {
              base.Connection = new OleDbConnection(connectionString);
         }
    }
