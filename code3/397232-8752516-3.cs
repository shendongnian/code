    SqlConnection conn = new SqlConnection(YourConnectionStringHere);
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;
    cmd.CommandText = 
        "select " +
        "    username, " +
        "    isnull([role 1] + ', ', '') + " +
        "    isnull([role 2] + ', ', '') + " +
        "    isnull([role 3], '') as Roles " +
        "from UserData";
    
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    Datatable YourData = new DataTable();
    
    try
    {
        sda.Fill(YourData);
    
        GridView1.DataSource = YourData;
        GridView1.Bind();
    }
    catch
    {
        sda.Dispose();
        // handle your error
    }
