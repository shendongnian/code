    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand cmd = connection.CreateCommand())
        {
            cmd.CommandText = "SELECT * FROM teams";
            connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    dataGridView.Visible = true;
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView.DataSource = dt;
                }
                else
                {
                    dataGridView.Visible = false;
                }
            }
        }
    }
