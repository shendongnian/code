    DateTime dt = datetimepicker.Value;
    //Connection string to connect to access database
    string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\mydatabase.mdb;";
    
    string strSql = String.Format("SELECT * FROM YOUTABLE WHERE DateCol = '{0}'", dt);
    OleDbDataAdapter adap = new OleDbDataAdapter(strSql, new OleDbConnection(strConn));
    DataTable table = new DataTable();
    adap.Fill(table);
    GridView1.DataSource = table;
    GridView1.DataBind();
