    public void ReturnOperators()
        {            
            string query = @"SELECT TOP 1000 [Store],[opid],[last4],[repeatserve_Count] FROM [POS].[dbo].[LVRC_Summary] WHERE repeatserve_count > 5";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DtOperators.Clear();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DtOperators = dt;
            }
        }
