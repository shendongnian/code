    Process processAlias = null;
    Association assocAlias = null;
    FieldOfActivity actAlias = null;
    var subquery = QueryOver.Of<MonthCapacity>()
        .Where(m => m.Association == assocAlias)
        .Select(Projections.Sum(m => m.Hours));
    var results = session.QueryOver<Project>()
        .JoinQueryOver(p => p.Processes, () => processAlias)
        .JoinQueryOver(p => p.Associations, () => assocAlias)
        .JoinAlias(p => p.FieldOfActivity, () => actAlias)
        .Select(p => new ChartDto { Project = p, FieldOfActivity = actAlias, Hours = Projections.Subquery(subquery) })
        .List();
