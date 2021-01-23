    public DateTime LastActivity
    {
        get {
            DateTime maxLastUpdated = Pictures.Max(x => x.LastUpdated);
            return maxLastUpdated > this.LastUpdated
                ? maxLastUpdated
                : this.LastUpdated) };
    }
