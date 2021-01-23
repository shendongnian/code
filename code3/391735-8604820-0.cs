    public void GetDataAndDisplay()
    {
        DataTable myData = new DataTable();
        myData = GetDataFromDb();
        LoopThroughTable(myData);
    }
    public DataTable GetDataFromDb()
    {
        // you can also stored your connection string in the web.config file
        //  and utilize ConfigurationManager class
        SqlConnection dbConn = new SqlConnection("your connectionstring here");
        SqlCommand GetData = new SqlCommand();
        GetData.Connection = dbConn;
        GetData.CommandText = "select col1, col2 from yourTable";
    
        SqlDataAdapter dataAdapter = new SqlDataAdapter(GetData);
        DataTable YourData = new DataTable();
    
        try
        {
            dataAdapter.Fill(YourData);
        }
        catch (Exception ex)
        {
            // do something
        }
    
        return YourData;
    }
    
    public void LoopThroughTable(DataTable dataTable)
    {
        foreach(DataRow row in dataTable.Rows)
        {
            // construct your html strings here...
        }
    }
