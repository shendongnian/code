    public string[][] GetRecordFields(string selectedRecord) {
      return (
        from record in _recordMasterList
        where record.Item1 == selectedRecord
        select new string[] {
          record.Item2.Keys,
          record.Item2.Values
        }
      ).ToArray();
    }
