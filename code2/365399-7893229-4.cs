    IEnumerable<SortedRecord> GetSortedRecords(IQueryable<Record> records
        , Func<SortedRecord, bool> sortedRecordPredicate)
    {
        return
          records.Where(rec => rec.RecordGroupID == 7)
            .OrderBy(rec => rec.RecId).AsEnumerable()
            .Select((rec, i) => new SortedRecord{ Sequence = i, Record = rec })
            .Where(sortedRecordPredicate);
    }
    var result = GetSortedRecords(records, rec => rec.Record.RecordID = 35);
