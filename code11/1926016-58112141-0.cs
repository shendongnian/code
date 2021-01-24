    from p in Personnel
    join pdl in PersonnelDrivingLicense on p.Id equals pdl.PersonnelId
    group p by p.Id into g
    select new Personnel
    {
        Id = g.Key,
        PersonnelDrivingLicense = g.Select(x => x.PersonnelDrivingLicense).ToList()
    }
