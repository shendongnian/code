        public DataTable GetValue(string name)
        {
            string connection = @"Data Source=DESKTOP-M5TQV9A;Initial Catalog=ALLTEST;Integrated Security=True";
            DataTable dt;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("up_searchUsers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SearchName", SqlDbType.VarChar).Value = name;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
