    using (SqlConnection con1 = new SqlConnection(connectionstring))
     {
      using (SqlCommand cmd1 = new SqlCommand("your_procedure_name"))
        {
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Connection = con1;                                               
	    SqlParameter Param = cmd1.Parameters.AddWithValue("@parameter_name", dt);
	    Param.SqlDbType = SqlDbType.Structured;
            con1.Open();
            cmd1.ExecuteNonQuery();
            con1.Close();
        }
    }
