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
                                 ReportId = Uniferon_Reports.FirstOrDefault(x => 
                                     x.FK_PartnerId == partnerId && 
                                     x.FK_PackageId == i.PackageId && 
                                     x.Date == date)
                                 // etc...
                             });
        date = date.AddMonths(1);
    }
