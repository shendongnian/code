    public IQueryable GetData(string DataType)
    {
        // Get a list of the types we need
        var requiredTypes = WebHelpers.LocalList.Select(l => l.Type)
                                      .Distinct().ToArray();
        // Retrieve all the relevant rows from the database
        var dbData = db.All<DatabaseObject>()
                                      .Where(d => requiredTypes.Contains(d.Type))
                                      .ToArray();
        // Do the join locally
        return (
            from t in dbData
            join e in WebHelpers.LocalList
            on t.Type equals e.Type
            orderby t.DateOccurred descending
            select t
        ).Where(e => e.Category == TransType);
    }
