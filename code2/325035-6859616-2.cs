    SqlConnection  conn = new SqlConnection("Connectionstring")
    SqlCommand cmd = new SqlCommand ();
    
    cmd.CommandText = " Select * From GetUsersID";
    cmd.Connection = conn;
    conn.Open();
    DataTable dt  = new DataTable();
    
    dt.Load(cmd.ExecuteReader());
    conn.Close();
    
    DropDownList1.DataSource = dt;
    DropDownList1.DataTextField = "Name";
    DropDownList1.DataValueField = "ID";
    DropDownList1.DataBind(); `
