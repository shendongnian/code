    public DateTime LastActivity
    {
        get
        {
            var picturesMax = Pictures.Max(x => x.LastUpdated);
            return picturesMax > this.LastUpdated
              ? picturesMax
              : this.LastUpdated)
        };
    }
