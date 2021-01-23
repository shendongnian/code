    while (date <= endDate)
    {
        var result = Uniferon_Packages
            .Where(i => 
                Uniferon_Partners_Packages_Relation.Any(rel => rel.FK_PartnerId == i.PackageId) &&
                rel.StartDate <= date && (!rel.EndDate.HasValue || rel.EndDate >= date))
            .Select(i => new
                             {
                                 i.PackageId,
                                 i.Name,
                                 Date = date,
                                 ReportId = GetReportId(i, partnerId, date)
                                 // etc...
                             });
        date = date.AddMonths(1);
    }
    private int GetReportId(Uniferon_Package pack, int partnerId, DateTime date)
    {
        var report = Uniferon_Reports.FirstOrDefault(x => 
            x.FK_PartnerId == partnerId && 
            x.FK_PackageId == pack.PackageId && 
            x.Date == date);
        return report != null
            ? report.ReportId
            : 0;
    }
