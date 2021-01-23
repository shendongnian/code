    using (SqlConnection connection = new SqlConnection("...")) {
      connection.Open();
      using (SqlTransaction transaction = connection.BeginTransaction())
      using (SqlCommand command = connection.CreateCommand()) {
        command.Transaction = transaction;
        command.CommandText = "INSERT INTO ...";
        // add parameters...
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      // Reference to question 1: At this point in the code, assuming NO unhandled
      // exceptions occurred, the connection object is still open and can be used.
      // for example:
      using (SqlCommand command = connection.CreateCommand()) {
        command.CommandText = "SELECT ...";
        using (SqlDataReader reader = command.ExecuteReader()) {
          while (reader.Read()) {
            // do awesome processing here.
          }
        }
      }
    }
