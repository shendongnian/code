    DateTime dt = datetimepicker.Value;
    //Connection string to connect to access database
    string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\mydatabase.mdb;";
    using (var connection = new OleDbConnection(strConn)) {
       string strSql = String.Format("SELECT * FROM YOURTABLE WHERE DateCol = '{0}'", dt);
       using (var adap = new OleDbDataAdapter(strSql, connection)) {
          DataTable table = new DataTable();
          adap.Fill(table);
          GridView1.DataSource = table;
          GridView1.DataBind();
       }
    ]
