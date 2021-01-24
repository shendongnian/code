    var hours = Enumerable.Range(1, 24);
    // Build sequence of ranges of all start..end hours.
    // I put in an extra select to-anon for future clarity.
    // SelectMany takes returns of [10,11,12],[1,2],[11,12] eg.
    // and turn them into a single sequence like [10,11,12,1,2,11,12]
    var exclusions = Mails
        .Select(m => new {
           Start = m.DateAndTime.Hour,
           Duration = GetRoundedTransferTime(TransferSpeed, m.Size),
        })
        .SelectMany(s => Enumerable.Range(s.Start, s.Duration));
    // all hours in day minus exclusion
    // (ranges, already expressed as individual hours)
    return hours.Except(exclusions)
        .OrderBy(h => h) // technically not needed here
        .ToList();
