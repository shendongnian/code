    using (SqlConnection conn = new SqlConnection("connectionString"))
    {
        conn.Open();
    
        using (SqlTransaction trans = conn.BeginTransaction())
        using (SqlCommand comm = new SqlCommand("The Above SQL", conn, trans))
        {
            comm.ExecuteNonQuery();
            trans.Commit();
        }
    }
