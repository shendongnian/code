    var results = session.QueryOver<Project>()
        .JoinQueryOver(p => p.Processes, () => processAlias)
        .JoinQueryOver(p => p.Associations, () => assocAlias)
        .JoinAlias(p => p.FieldOfActivity, () => actAlias)
        .SelectList(list => list
            .Select(p => new ChartDto { Project = p, FieldOfActivity = actAlias, Hours = 0 })
            .Select(Projections.Subquery(subquery))
        )
        .List<object[]>()
        .Select(objects =>
        {
            var chart = (ChartDto)objects[0];
            chart.Hours = (int)objects[1];
            return chart;
        });
