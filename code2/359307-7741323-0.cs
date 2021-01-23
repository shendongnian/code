    using(var connection = new SqlConnection(connectionString)) {
        connection.Open();
        using(var transaction = connection.BeginTransaction("Transaction")) {
            foreach(var item in list) {
                using(var command = connection.CreateCommand()) {
                    command.Transaction = transaction;
                    command.CommandText = // set the command text using item
                    command.ExecuteNonQuery();
                }
            }
            transaction.Commit();
        }
    }
