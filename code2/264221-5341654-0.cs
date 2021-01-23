    public void UpdateRecords(Record[] recs)
    {
        // look for deleted records
        foreach (Record rec in UnitOfWork.Records.ToList())
        {
            var copy = rec;
            if (!recs.Any(x => x.Id == copy.Id)
            {
                // if not in the new collection, remove from database
                Record deleted = UnitOfWork.Records.Single(p => p.Id == copy.Id);
                UnitOfWork.Remove(deleted);
            }
        }
        // rest of method code deleted
    }
