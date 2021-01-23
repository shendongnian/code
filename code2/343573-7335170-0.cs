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
    }
