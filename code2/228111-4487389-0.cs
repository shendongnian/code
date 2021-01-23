    public static IEnumerable<BrowserVisits> SumGroups(
        IEnumerable<BrowserVisits> visits)
    {
        return visits.GroupBy(
            i => i.BrowserName,
            (name, browsers) => new BrowserVisits() {
                BrowserName = name,
                Visits = browsers.Sum(i => i.Visits)
            });
    }
