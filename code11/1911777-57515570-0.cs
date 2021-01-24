    public static string GetDataJSONArray(
	    string procName,
	    string connection = null
    )
    {
	    if (connection == null)
		    connection = defaultConnection;
	    var sql = procName;
	    StringBuilder sb = new StringBuilder();
	    using (SqlConnection sqlConnection = new SqlConnection(connection))
	    {
		    sqlConnection.Open();
		    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
		    cmd.CommandTimeout = defaultTimeout;
		    cmd.CommandType = CommandType.StoredProcedure;
		    using (SqlDataReader reader = cmd.ExecuteReader())
		    {
			    while (reader.Read())
			    {
				    sb.Append(reader.GetString(0));
			    }
		    }
	    }
        var json = sb.ToString();
        if (string.IsNullOrWhiteSpace(json))
        {
            json = "[]";
        }
	    return json;
    }
