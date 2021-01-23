         using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Table", conn))
                {
                   DataTable dt = new DataTable();
                     ad.Fill(dt);
                   dataGridView1.DataSource = dt;
                }
            }
           
