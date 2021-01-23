    using NHibernate.Linq;
    var archiveDates = from entry in session.Query<Entry>()
                       group entry by new { entry.Published.Year, entry.Published.Month } into entryGroup
                       orderby entryGroup.Key.Year descending, entryGroup.Key.Month descending
                       select new ArchiveDate
                       {
                           Year = entryGroup.Key.Year,
                           Month = entryGroup.Key.Month,
                           EntryCount = entryGroup.Count()
                       };
