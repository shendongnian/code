    SqlConnection con = new SqlConnection(); 
    DataSet ds = new DataSet(); 
    con.ConnectionString = @"Data Source=TOP7\SQLEXPRESS;Initial Catalog=t1;Persist Security Info=True;User ID=Test;Password=t123";
    string query = "Select * from tbl_User"; 
    SqlCommand cmd = new SqlCommand(query, con); 
    cmd.CommandText = query;
    con.Open(); 
    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
    adpt.Fill(ds);
    comboBox1.Items.Clear();
    comboBox1.DisplayMember = "UserName";
    comboBox1.ValueMember = "UserId";
    comboBox1.DataSource = ds.Tables[0];
    
    ------------------------------------------------------------------------
