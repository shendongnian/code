    var groupedList = incidentsRiskMatrix
        .GroupBy(u => new
        {
            u.Date.Month,
            u.Date.Year
        })
        .Select(grp => new IncidentTrend
        {
            Month = grp.Key.Month,
            Year = grp.Key.Year,
                           // from each group
            IncidentsByType = grp
                // group the items by their IncidentName
                .GroupBy(x => x.IncidentName)
                // and select new IncidentByType
                .Select(x => new IncidentsByType
                {
                    // by getting the amount of items in the group
                    Total = x.Count(),
                    // and the key of the group
                    Name = x.Key
                })
                .ToList()
        })
        .ToList();
