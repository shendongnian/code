    public void UpdatePhrase(PHRASE phraseColumn, bool value, string phraseId) 
    {
       sql = "UPDATE Phrase SET " + phraseColumn.Text() + " = @v WHERE PhraseId = @id";
       List<SqlParameter> prms = new List<SqlParameter>
       {
          new SqlParameter {ParameterName = "@v", SqlDbType = SqlDbType.Boolean, Value = value},
          new SqlParameter {ParameterName = "@id", SqlDbType = SqlDbType.NVarChar, Value = phraseId}
       };
       App.DB.RunExecute(sql, prms);
    }
