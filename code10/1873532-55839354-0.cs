    [HttpPost]
    public List<TestRecord> Search(TestRecord testRecord){
        List<TestRecord> records = _db.TestRecords
                     .Where(tr => String.IsNullOrEmpty(testRecord.TestType) ? true : tr.TestType == testRecord.TestType)
                     .Where(tr => String.IsNullOrEmpty(testRecord.Part.Name) ? true : tr.Part.Name == testRecord.Part.Name)
                     //etc...
                     .ToList();
        return records;
    }
