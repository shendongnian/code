    public IEnumerable<Question> GetQuestions()
    {
        using (var conn = new OracleConnection("put your CS string here or fetch from app.config"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT MCQ_ID, MCQ_TITLE FROM MCQ_QUESTIONS WHERE Poll_ID = 1";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Question
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("MCQ_ID")),
                        Title = reader.GetString(reader.GetOrdinal("MCQ_TITLE"))
                    };
                }
            }
        }
    }
