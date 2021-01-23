    IEnumerable<Interval> missingIntervals =
        Enumerable.Range(list.Min(listMember => listMember.TIME_KEY), list.Max(listMember => listMember.TIME_KEY))
                  .Where(enumMember => enumMember % intervalDistance == 0)
                  .Select(enumMember => new Interval { TIME_KEY = enumMember}
                  .Except(list);
