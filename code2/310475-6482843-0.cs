    class Connection
    {
         OleDbConnection conn;
         OleDbCommand cmd;
         public Connection()
         {
              string connnstr = "Driver={MySQL ODBC 5.1 Driver};uid=ab ; password=pass;server=www.myweb.com;database=mydb;port=3306";
              conn = new OleDbConnection(connstr);
              cmd = new OleDbCommand();
              cmd.Connection = conn;
         }
         public OleDbDataReader GetData()
         {
            ....
         }
    }
