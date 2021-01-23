    string columnFourName = "Col4";
    string columnFourName = "Col5";
    List<object> columnFourItems = new List<object>()
    List<object> columnFiveItems = new List<object>()
    SqlConnection oConn = new SqlConnection("SomeConnstring);
    oConn.Open();
    SqlCommand oComm = new SqlCommand("SELECT * FROM Stuff", oConn);
    SqlDataAdapter sda = new SqlDataAdapter(oComm);
    DataTable dt = new DataTable();
    sda.Fill(dt);
    dt.Columns.Add(columnFourName, typeof(object));
    dt.Columns.Add(columnFiveName, typeof(object));
    for (int row = 0; row < dt.Rows.Count; row++)
    {
        dt.Rows[row][3] = columnFourItems[row];
        dt.Rows[row][4] = columnFiveItems[row];
    }
