    public IEnumerable<IEnumerable<int>> GetWindows(IEnumerable<int> events)
    {
        while (events.Any())
        {
            events = events.SkipWhile(x => x > 5 && x < 95);
            if (events.Any())
            {
                var isLow = events.First() <= 5;
                var res = events.TakeWhile(x => isLow ? x <= 5 : x >= 95).ToList();
                if (res.Count >= 5)
                    yield return res;
                events = events.Skip(res.Count);
            }
        }
    }
