        public static DataSet GetAll(int id)
        {
            using (SqlConnection con = new SqlConnection(Database.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ContactGetAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet dsData = new DataSet();
                        da.Fill(dsData);
                        return dsData;
                    }
                }
            }
        }
