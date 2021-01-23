    public List<SingleEvent> GetAllSingleEvents(DateTime StartDate)
    {
        var result =
            from eveItemDB in App.MyDatabase.Query<SingleEventDB, DateTime, string>("BYDATETIME")
            where (eveItemDB.Index >= StartDate)
            orderby eveItemDB.Index
            select new SingleEvent
            {
                UniqueId = eveItemDB.LazyValue.Value.UniqueId,
                NextDateTime = eveItemDB.Index,
                Details = eveItemDB.LazyValue.Value.Details,
                Location = eveItemDB.LazyValue.Value.Location
            };
        return result.ToList();
    }
