    var q1 = repo.GetQuery<PrintJob>()
        .GroupBy(pj => pj.UserName)
        .Select(g => new PrintJobByUserReportItem(g));
    
    var q2 = repo.GetQuery<PrintJob>()
        .GroupBy(pj => pj.Departmen)
        .Select(g => new PrintJobByDepartmenReportItem(g)
        { 
            DepartmentName = g.Key,
            NumberOfUsers = g.Select(u => u.UserName).Distinct().Count()
        });
