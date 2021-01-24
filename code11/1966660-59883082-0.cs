    private void DeleteById(int memberId)
    {
       // or pull the connString from config somewhere
       const string connectionString = "[your connection string]";
       using (var connection = new SqlConnection(connectionString))
       {
           connection.Open();
        
           using (var command = new SqlCommand("DELETE FROM Members WHERE MemberId = @memberId", connection))
           {
               command.Parameters.AddWithValue("@memberId", memberId);
               command.ExecuteNonQuery();
           }
       }
