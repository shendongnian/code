    // first get the groups:
    var groups = items.GroupBy(i => i.ID);
    // find the max date in each group
    var maxDates = groups.Select(g => g.OrderByDescending(i => i.Date).First());
    // now find the earliest max date
    var minDate = maxDates.OrderBy(i => i.Date).First();
      
