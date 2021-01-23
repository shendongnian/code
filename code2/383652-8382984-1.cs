    var query = from e in session.Query<Entry>()
                group e by new { e.Published.Year, e.Published.Month } into entryGroup
                select new
                {
                    entryGroup.First().Published,
                    EntryCount = entryGroup.Count()
                };
    var archiveDates = from a in query.AsEnumerable()
                       orderby a.Published.Year descending, a.Published.Month descending
                       select new
                       {
                           Year = a.Published.Year,
                           Month = a.Published.Month,
                           EntryCount = a.EntryCount,
                       };
