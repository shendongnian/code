    IEnumerable<DateTime> DistinctYearMonths = context.Publications
        .Select(p => new { p.ReleaseDate.Year, p.ReleaseDate.Month })
        .Distinct()
        .ToList() // excutes query
        .Select(x => new DateTime(x.Year, x.Month, 1)); // copy anonymous objects
                                                        // into DateTime in memory
