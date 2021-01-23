    SqlCommand cmd = new SqlCommand(query, c);
    
    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                DataTable t = new DataTable();
                a.Fill(t);
            }
