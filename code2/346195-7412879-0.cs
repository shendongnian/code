    OleDbConnection oleDbConnection = new OleDbConnection(
      "Provider=Microsoft.Jet.OLEDB.4.0;" +
      "Data Source=D:\\Users\\name\\Desktop\\test.xls;" +
      "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'");
    oleDbConnection.Open();
    //Get columns
    DataTable dtColumns = oleDbConnection.GetSchema("Columns", new string[] { null, null, "Tabelle1$", null });
    List<string> columns = new List<string>();
    foreach (DataRow dr in dtColumns.Rows)
      columns.Add(dr[3].ToString());
    string colName = columns.Find(item => item.Substring(0,3) == "QTA");
    DataSet ds = new DataSet();
    OleDbDataAdapter da = new OleDbDataAdapter
      ("SELECT * FROM [Tabelle1$] WHERE [" + colName + "] > 0", oleDbConnection);
    da.Fill(ds);
    dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
    oleDbConnection.Close();
