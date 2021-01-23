        using (SqlConnection conn = new SqlConnection(@"ConnectionString"))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT tim,com,pic FROM ten", conn))
            {
                conn.Open();
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                        MainGrid.DataSource = ds;
                    }
                } 
 
                conn.Close();
            }
        }
