    SqlConnection con = new SqlConnection(dc.Con);
    con.Open();
    da.SelectCommand = new SqlCommand("SELECT * FROM Clients", con);
    
    da.Fill(dt);
    con.Close();
