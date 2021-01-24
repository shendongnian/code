        public class DB
        {
            private string ConStr = "Your connection string";
            public DataTable GetCountryData(string nC)
            {
                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(ConStr))
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Voucher WHERE Name_Country= @nC", cn))
                {
                    cmd.Parameters.Add("@nC", SqlDbType.VarChar, 100).Value = nC;
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
                return dt;
            }
        }
