    using (SqlCeTransaction transaction = this.connection.BeginTransaction())
    {
        using (SqlCeCommand command = new SqlCeCommand(query, connection))
        {
            command.Transaction = transaction;
            command.ExecuteNonQuery();
        }
        transaction.Commit(CommitMode.Immediate);
    }
