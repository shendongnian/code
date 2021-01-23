    for(int i = 0; i < data.Rows.Count; i++)
    {
      if (_DataCopyLogMaintenance.ContainedInDataCopyLog(data.Rows[i]))
      {
        newData.Rows.RemoveAt(i);
      }
    }
