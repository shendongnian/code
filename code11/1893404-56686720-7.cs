    SqlConnection con = new SqlConnection("YourConnection String");
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand("storedprocedure", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@p1", whatever); //if you have parameters.
    SqlDataAdapter da= new SqlDataAdapter(cmd);
    da.Fill(ds);
    con.Close();
