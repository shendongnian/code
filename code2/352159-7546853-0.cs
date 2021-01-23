    SqlConnection con = new SqlConnection("ConnectionString");
            SqlCommand cmd = new SqlCommand("GetDepartmentName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = _ID });
            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar) { Size = 50, Direction = ParameterDirection.Output });
            con.Open();
            cmd.ExecuteNonQuery();
        _Name = cmd.Parameters["@Nume"].Value.ToString();
