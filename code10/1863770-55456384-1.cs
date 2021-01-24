    DateTime startTime = ...
    var result = Infos.Select(info => new
    {
         StartTime = info.StartTime.StartDatetime(),
         EndTime = info.EndTime.EndDateTime(),
         // select the Info properties you actually plan to use:
         ...
         // or select the complete Info:
         Info = info,
    })
    .Where(info => info.StartTime <= startTime && startTime <= info.EndTime)
    .OrderBy(info => info.StartTime)
    // Only if you prefer to throw away your converted StartTime / EndTime:
    .Select(info => info.Info);
