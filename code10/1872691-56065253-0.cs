    private IEnumerable<SqlDataRecord> SendRowsToProc(SqlDataReader Reader)
    {
      if (!Reader.HasRows)
      {
        yield break;
      }
    
      SqlDataRecord _ResultRow = new SqlDataRecord(new SqlMetaData[] {
                 new SqlMetaData("id", SqlDbType.Int, true, true, SortOrder.Unspecified, 0),
                 new SqlMetaData("value", SqlDbType.Float)
                                                        });
    
      while (Reader.Read())
      {
        _ResultRow.SetDouble(1, Reader.GetDouble(0));
    
        yield return _ResultRow;
      }
    }
