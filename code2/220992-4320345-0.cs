    public DateTime LastActivity
    {
        get
        {
            return Pictures.Aggregate(LastUpdated,
                                (a, x) => x.LastUpdated > a ? x.LastUpdated : a);
        }
    }
