    var SQL = new StringBuilder();
    // Build SQL here. use SQL.AppendLine("SELECT ...")
    var cn = new 
    System.Data.SqlClient.SqlConnection(your_sql_connection_string);
	var da = new System.Data.SqlClient.SqlDataAdapter(SQL.ToString(), cn);
	var datatbl = New DataTable();
    da.SelectCommand.Parameters.Add("@GivenGroup", SqlDbType.Int).Value = 1; // use parameterization always.
    try {
        da.SelectCommand.Connection.Open();
        da.Fill(datatbl);
    }
    catch (Exception ex)
    {
        // error handling here
    }
    finally
    {
        cn.Close();
        cn.Dispose();
        da.Dispose();
    }
