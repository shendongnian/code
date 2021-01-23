    public DataSet GetDate(string SqlString)
    {
    SqlConnection sqlConn = new SqlConnection("CONNECTION STRING GOES HERE");
    DataSet ds = new DataSet();
    
    SqlDataAdapter adapter = new SqlDataAdapter(SqlString, sqlConn);
    adapter.Fill(ds);
    
    return ds;
    
    }
    
    public void LoopThroughDataExample(DataSet ds)
    {
    foreach(DataTable dt in ds)
    {
    foreach(DataRow dr in dt)
    {
    Console.WriteLine(String.Format("Value is: {0}", dr["DBColumnName"])); // Replace DBColumnName with the name of columns in the Database Table that you want to Extract.
    }
    }
    
    }
