    private IEnumerable<SqlDataRecord> SendRowsToProc(SqlDataReader reader)
    {
      if (!reader.HasRows)
      {
        yield break;
      }
    
      SqlDataRecord resultRow = new SqlDataRecord(new SqlMetaData[] {
                 new SqlMetaData("id", SqlDbType.Int, true, true, SortOrder.Unspecified, 0),
                 new SqlMetaData("value", SqlDbType.Float)
                                                        });
    
      while (reader.Read())
      {
        resultRow.SetDouble(1, reader.GetDouble(0));
    
        yield return resultRow;
      }
    }
