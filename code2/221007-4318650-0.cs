    string sql = "select COUNT(dataset1) from dbo.ste where project = 'whatever' and date = '11/30/10'";
    SqlConnection con = new SqlConnection("Data Source= Watchmen ;Initial Catalog= doeLegalTrending;Integrated Security= SSPI");
    con.Open();
    SqlCommand cmd = new SqlCommand(sql, con);
    int count = Convert.ToInt32(cmd.ExecuteNonQuery());
    con.Close();
    
    if(count != 0)
    {
    //do this string
    }
    else
    {
    
    //do this one
    }
