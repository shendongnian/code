    SqlConnection conn = new SqlConnection("yourConnectionStringHere");
    SqlCommand GetData = new SqlCommand();
    GetData.Connection = conn;
    GetData.CommandText = "select * from yourTable"; // or whatever your query is, whether ad hoc or stored proc
    // add parameters here if your query needs it
    SqlDataAdapter sda = new SqlDataAdapter(GetData);
    DataTable YourData = new DataTable();
    
    try
    {
        sda.Fill(YourData);
    }
    catch
    {
        sda.Dispose();
        conn.Dispose();
    }
