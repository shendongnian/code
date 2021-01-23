    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ToString());
    SqlCommand read_command = new SqlCommand("SELECT SUM(Length) FROM tbl_test WHERE TITLE LIKE '@t%'", con);
            read_command.Parameters.Add("@t", SqlDbType.NVarChar).Value = Str;
            SqlDataReader read_rd;
            string SUM ;
            try
            {
                con.Open();
                read_rd = read_command.ExecuteReader();
                if (read_pass_rd.HasRows)
                {
                    while (read_rd.Read())
                    {
                        SUM = read_rd.GetString(0);
                    }
                }
                read_rd.Close();
                con.Close();
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
