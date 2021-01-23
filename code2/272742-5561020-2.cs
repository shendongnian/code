    public IEnumerable<MyModels.StatusLookup> GetAll()
    {
        var results = Database.Current.pStatusLookupLoadAll()
            .ExecuteTypedList<MyModels.StatusLookup>();
        // Note: no need for a cast, as the return value is now
        // already strongly typed as IEnumerable<MyModels.StatusLookup>.
        return results.AcceptChangesAndYield();
    }
