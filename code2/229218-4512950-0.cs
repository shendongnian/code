    private Dictionary<String,String> cache;
    private void FillCache()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM vwXMLFeedData", conn);
            conn.Open();
            cache = new Dictionary<String,String>();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    cache.Add(rdr["Title"].ToString(), rdr["URL"].ToString());
                }
            }
        }
    }
