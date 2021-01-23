    SqlConnection conn = new SqlConnection(YourConnectionStringHere);
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;
    cmd.CommandText = 
        "select " +
        "    username, " +
        "    [role 1] + ', ' + [role 2] + ', ' + [role 3] as Roles " +
        "from UserData";
    
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    Datatable YourData = new DataTable();
    
    try
    {
        sda.Fill(YourData);
    
        YourGridView.DataSource = YourData;
        YourGridView.Bind();
    }
    catch
    {
        sda.Dispose();
        // handle your error
    }
