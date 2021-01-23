    var q1 = repo.GetQuery<PrintJob>()
        .GroupBy(pj => pj.UserName)
        .EXTENSIONNAME()
        .Select(g => new PrintJobByDepartmenReportItem
                     {
                        PrintJobReportItem = g.PrintJobReportItem,
                        DepartmentName = g.GROUPING.Key,
                        NumberOfUsers = g.GROUPING.Select(u => u.UserName).Distinct().Count()
    
                     });
