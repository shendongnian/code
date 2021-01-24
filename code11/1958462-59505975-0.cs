    SqlConnection con = new SqlConnection("server= localhost;Database = Vehiculum ;integrated Security = true");
    SqlCommand cmd = new SqlCommand("insertservisi", con);
    cmd.CommandType = CommandType.StoredProcedure;
	// *DEFINE* the parameters - once, before the loop - in the same order they're defined in the stored procedure!
    cmd.Parameters.Add("@emri", SqlDbType.VarChar, 50);
    cmd.Parameters.Add("@mbiemri", SqlDbType.VarChar, 50);
    cmd.Parameters.Add("@telefoniI", SqlDbType.VarChar, 50);
	// and so forth, for all your parameters
	
	// now open connection, loop
    con.Open();
	for (int i = 0; i < dtgservisimi.Rows.Count; i++)
    {
	    // set the parameter values
        cmd.Parameters["@emri"].Value = txtemri.Text;
        cmd.Parameters["@mbiemri".Value = txtmbiemri.Text;
        cmd.Parameters["@telefoniI".Value =  txttelefoniI.Text;
    	// and so forth, for all your parameters
		// execute the procedure
        cmd.ExecuteNonQuery();
    }
	
    con.Close();
