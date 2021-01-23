    public IEnumerable<RecentTag> GetRecentTags(int numberofdays)
    {
        DateTime startdate = DateTime.Now.AddDays(-(numberofdays));
        IEnumerable<RecentTag> tags = Jobs
            .Where(j => j.DatePosted > startdate) // Can't use DateTime.Now.AddDays in Entity query apparently
            .SelectMany(j => j.Tags)
            .GroupBy(t => t, (k, g) => new RecentTag
            {
                TagID = k.TagID,
                Name = k.Name,
                Count = g.Count()
            })
            .OrderByDescending(g => g.Count)
            .Select(a => a);
    
        return tags;
    }
