        public DataTable QryData(string query)
        {
            using (SqlConnection con = new SqlConnection(_connstring))
            {
                try
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand(query, con);
                    SqlDataReader reader = comm.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return new DataTable();
        }
