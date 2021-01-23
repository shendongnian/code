        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd = null;
        List<int> catID = new List<int>();
        try
        {
            connection = new SqlConnection(connectionString);
            cmd = new SqlCommand("select CategoryID from Categories", connection );
            connection.Open();
           
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {   int i;
                i = Convert.ToInt32(dr["CategoryID"].ToString());
                catID.Add(i);
            }
        }
        finally
        {
            if (connection  != null)
                connection.Close();
        }
        return catID;
