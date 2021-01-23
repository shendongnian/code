    var rowcount = CriteriaTransformer.Clone(criteria);
    
    var goupprojections = Projections.ProjectionList();
    var projections = Projections.ProjectionList();
    foreach (var p in projection.Projections)
    {
        IProjection newProjection = null;
        switch (p.AggregateFunc)
        {
            case AggregateFuncTypeEnum.GroupProperty:
                newProjection = Projections.GroupProperty(p.Path);
                goupprojections.Add(Projections.GroupProperty(p.Path), p.Name);
                break;
            case AggregateFuncTypeEnum.Sum:
                newProjection = Projections.Sum(p.Path);
                break;
            default:
                newProjection = Projections.Property(p.Path);
                break;
        }
        projections.Add(newProjection, p.Name);
    }
    criteria.SetProjection(projections).SetResultTransformer(new AliasToBeanResultTransformer(projectionType));
    if (goupprojections.Aliases.Length == 0)
    {
        rowcount.SetProjection(Projections.RowCount())
    }
    else
    {
        rowcount.SetProjection(Projections.Count(goupprojections))
    }
    var results = criteria.Future();
    var count = rowcount.FutureValue<int>();
