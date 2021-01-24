    db.BeginTransaction();
    IList<Document> list = db.Get<Document>();
    List<Document> result = new List<Document>();
    foreach (var item in list)
    {
        item.ResetPeriods(); //todo: HACK! Preventing from lazy load of periods
        result.Add(item);
    }
    db.CommitTransaction();
    return result;
