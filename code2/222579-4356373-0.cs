    public int InsertResultItem(string runTag, int topicId,
        string documentNumber, int rank, double score)
    {
        // Apre la connessione e imposta il comando
        using (var connection = new SQLiteConnection(SomeConnectionString))
        using (var command = new connection.CreateCommand())
        {
            connection.Open();
            using (var tx = connection.BeginTransaction())
            {
                command.CommandText = "INSERT OR IGNORE INTO Result "
                    + "(RunTag, TopicId, DocumentNumber, Rank, Score) " +
                    "VALUES (@RunTag, @TopicId, @DocumentNumber, @Rank, @Score)";
                // Imposta i parametri
                command.Parameters.AddWithValue("@RunTag", runTag);
                command.Parameters.AddWithValue("@TopicId", topicId);
                command.Parameters.AddWithValue("@DocumentNumber", documentNumber);
                command.Parameters.AddWithValue("@Rank", rank);
                command.Parameters.AddWithValue("@Score", score);
                // Ottieni il risultato e chiudi la connessione
                var retval = command.ExecuteNonQuery();
                tx.Commit();
                return retval;
            }
        }
    }
