    var hours = Enumerable.Range(1, 24);
    // Build sequence of ranges of all start..end hours.
    // I put in an extra select to-anon for future clarity.
    // SelectMany takes returns of [10,11,12],[1,2],[11,12] eg.
    // and turns them into a single sequence like [10,11,12,1,2,11,12]
    var exclusions = Mails
        .Select(m => new {
           Start = m.DateAndTime.Hour,
           // Don't care if we run past > 24, although THIS MIGHT BE
           // A DEFECT IN THE ORIGINAL that should be addressed..
           Duration = GetRoundedTransferTime(TransferSpeed, m.Size),
        })
        // To address previous potential defect, build appropriate
        // sequence in here that understands how to 'wrap around' days.
        .SelectMany(s => Enumerable.Range(s.Start, s.Duration));
    // All hours in day minus exclusion
    // (exclusion ranges are already expressed as individual hours)
    return hours.Except(exclusions)
        .OrderBy(h => h) // technically not needed here
        .ToList();
