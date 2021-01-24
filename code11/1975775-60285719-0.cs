        protected void Load()
        {
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.AppSettings["Connection"]))
            using (SqlCommand com = new SqlCommand("StoredProcedure", objConn))
            {
                objConn.Open();
                com.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dr = com.ExecuteReader())
                {
                    if(dr.HasRows && dr.Read()) // <----- This is the change
                    {
                        txtLabel.Text = dr["label"].ToString();
                        txtLabel.Text = dr["label"].ToString();
                        txtLabel.Text = dr["label"].ToString();
                    }
                }
            }
        }
