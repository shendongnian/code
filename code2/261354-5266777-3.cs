    public static void InsertOrUpdateSales(string connection, string barCode, int quantity)
    {
        using(SqlConnection conn = new SqlConnection(connection))
        {
            using(SqlCommand comm = new SqlCommand("InsertOrUpdateSales", conn))
            {
                 comm.CommandType = CommandType.StoredProcedure;
                 comm.Paramters.AddWithValue("@bar_code", barCode);
                 comm.Paramters.AddWithValue("@quantity", quantity);
                 comm.ExecuteNonQuery();
             }
         }
    }
    
