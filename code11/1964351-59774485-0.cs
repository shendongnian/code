        Datatable dt = new Datatable();
    using (SqlConnection connection = 
                new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    queryString, connection);
                adapter.Fill(dt);
                return dt;
            }
        }
