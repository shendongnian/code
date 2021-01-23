    ICollection<Rate> ConvertRates(IEnumerable<RateSet> oldRates)
    {
        return oldRates.Select(x => new Rate
                                    {
                                         ID = x.ID,
                                         Options = ConvertOptions(x.Options)
                                    }).ToList();
    }
