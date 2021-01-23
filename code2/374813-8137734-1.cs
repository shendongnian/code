    // Skipped creating temp variable
    try {
       using (SqlConnection conn = new SqlConnection(this.ConnectionString))
       using (SqlCommand command = new SqlCommand("GetItem", conn) { CommandType = CommandType.StoredProcedure} ) {
                        
          command.Parameters.AddWithValue(@ID, ID);
          conn.Open();
          
          // reader is IDisposable, you can use using
          using (var reader = command.ExecuteReader(CommandBehavior.SingleRow)) {
              // Skipped parsing multiple result sets, you return after the first
              // otherwise there's no point using SingleRow 
              // If nothing is read, return default value
              return reader.Read() ? this.Convert(reader) : new ENT_AuctionBid();
          }
       }
    }
    catch (Exception ex) {
        // Handle your exception here
    }  
    // Return default value for error
    return new ENT_AuctionBid();
