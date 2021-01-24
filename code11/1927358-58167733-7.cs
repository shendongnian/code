    public Record GetNearestRecord(DateTime dateTime, IEnumerable<Record> records)
    {
        var nearestRecord = records.OrderBy(r => Math.Abs((r.Time - dateTime).TotalSeconds)).First();
        return new Record() { Id = nearestRecord.Id, Value = nearestRecord.Value, Time = dateTime };
    }
