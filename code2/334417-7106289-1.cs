    using (SqlConnection conn = new SqlConnection(""))
    using (SqlCommand comm = new SqlCommand("select * from somewhere", conn))
    {
        conn.Open();
    
        using (var r = comm.ExecuteReader())
        {
            foreach (DbDataRecord s in r)
            {
                string val = s.GetString(0);
            }
        }
    }
