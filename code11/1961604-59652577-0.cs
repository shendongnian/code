    var groupedEvents = dbContext.EventTrackings
        .Where(x => // where clause )
        .GroupBy(x => new { CreatedDate = x.CreatedDate.Date, x.EmployeeId })
        .OrderBy(x => x.Key.CreatedDate)
        .ToList();
