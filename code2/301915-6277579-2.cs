    using (var connection = this.connectionFactory.GetConnection())
    {
        connection.Open();
        using (TransactionScope scope = new TransactionScope())
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "foo";
                command.ExecuteNonQuery();
            }
            scope.Complete();
        }
    }
