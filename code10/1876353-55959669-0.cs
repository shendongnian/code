    usertrackingRange = (
    from eventLog in userTrackingContext.EventLog
    where eventLog.Machine.ToUpper().Split(
        '.',
        StringSplitOptions.RemoveEmptyEntries
    )[0].Trim().Equals(myMachine)
    select eventLog.Date
    ).Select(range => new VisibleRange {
       start = ctx.OrderByAscending(a => a.Date).First(),
       end = ctx.OrderByDescending(a => a.Date).First()
    }).First();
