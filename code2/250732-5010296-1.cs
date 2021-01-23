    public IEnumerable<IDataRecord> GetProductsFromDB()
    {
        string strConnection = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
    
        using (SqlConnection connection = new SqlConnection(strConnection))
        using (SqlCommand cmd = new SqlCommand("GetProducts", connection))
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
            connection.Open();
            using (var sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    yield return sdr;
                }
            }    
        }
    }
