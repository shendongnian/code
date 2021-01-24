    series = await query
        .GroupBy(o => new { EF.Property<DateTime>(o, propertyName).Date.Month, EF.Property<DateTime>(o, propertyName).Date.Year })
        .Select(g => new DateLineGraphItem 
            { Legend = new DateTime(g.Key.Year, g.Key.Month, 1), Number = g.Count() })
        .ToListAsync();
