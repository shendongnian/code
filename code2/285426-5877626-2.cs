    public  DataTable GetData()
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection("your connection here")
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "your stored procedure here";                    
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
