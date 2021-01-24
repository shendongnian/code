    var query = _db.TestRecords.AsQueryable();
    if (string.IsNullOrEmpty(testRecord.TestType))
    {
    	query = query.Where(x => x.TestType == testRecord.TestType);
    }
    if (string.IsNullOrEmpty(testRecord.Part.Name))
    {
    	query = query.Where(x => x.Part.Name == testRecord.Part.Name);
    }
    // or, you can use an intermediate variable before returning to debug
    return query.ToList();
