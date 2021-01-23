    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Srno");
    dataTable.Columns.Add("Date");
    dataTable.Columns.Add("Time");
    dataTable.Columns.Add("Symbol");
    
    while ((line = file.ReadLine()) != null)
    {
        DataRow row = dataTable.NewRow();
        string[] s =  line.Split(',');
        row["Srno"] = s[0];
        row["Date"] = s[1];
        row["Time"] = s[2];
        row["Symbol"] = s[3];
    }
    
    //Add to your GridView that is in your aspx file
    gridView.DataSource = dataTable;
    gridView.DataBind();
