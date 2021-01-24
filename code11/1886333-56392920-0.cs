    // create and open a connection object
	SqlConnection conn = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
    conn.Open();
    // 1.  create a command object identifying the stored procedure
    SqlCommand cmd  = new SqlCommand("CustOrderHist", conn);
    // 2. set the command object so it knows to execute a stored procedure
    cmd.CommandType = CommandType.StoredProcedure;
    // 3. add parameter to command, which will be passed to the stored procedure
    cmd.Parameters.Add(new SqlParameter("@CustomerID", custId));
    // execute the command
    SqlDataReader rdr = cmd.ExecuteReader();
