    public KeyValuePair<string, List<KeyValuePair<string, int>>>[] ChartDayByDay(int days, string locale)
    {
        return db
            .XBLRegionalInfos
            .Where(x => string.IsNullOrEmpty(locale) || x.RegionId == locale)
            .Where(x => x.PublishDate > DateTime.Today.AddDays(days * (-1)))
            .GroupBy(x => new {x.PublishDate.Date, x.RegionId})
            .Select(x => new {x.Key, Count = x.Count()})
            .GroupBy(x => x.Key.Date)
            .Select(x =>
                    new KeyValuePair<string, List<KeyValuePair<string, int>>>(
                        x.Key.ToString(),
                        x.Select(y => new KeyValuePair<string, int>(y.Key.RegionId, y.Count)).ToList()))
            .ToArray();
    }
