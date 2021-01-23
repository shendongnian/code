    Process processAlias = null;
    Association assocAlias = null;
    MonthCapacity capAlias = null;
    FieldOfActivity actAlias = null;
    var query = session.QueryOver<Project>()
        .JoinQueryOver(p => p.Processes, () => processAlias)
        .JoinQueryOver(p => p.Associations, () => assocAlias)
        .JoinAlias(p => p.FieldOfActivity, () => actAlias)
        .JoinQueryOver(p => p.MonthCapacities, () => capAlias)
        .Select(p => new ChartDto { Project = p, FieldOfActivity = actAlias, Hours = capAlias.Hours })
        ;
