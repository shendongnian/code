    SqlConnection connection = null;
            SqlDataReader dr= null;
            SqlCommand cmd = null;
    List<int> catID = new List<int>();
            try
            {
                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand("select CategoryID from Categories", connection );
    
                connection.Open();
    
    
                
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    catID.Add(Convert.ToInt32(dr["CategoryID"].ToString()));
                }
    
    
            }
            finally
            {
                if (connection  != null)
                    connection.Close();
            }
            return catID;
