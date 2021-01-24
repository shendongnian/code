    // get IDs to look for in CurrentLocation
    var subQuery1 = QueryOver.Of<LocationEntity>()
        .Where(l => l.Name == LocationNameEnum.LA)
        .Select(x => x.Id);
    
    // get IDs to look for in NextDestination
    var subQuery2 = QueryOver.Of<LocationEntity>()
        .Where(l => l.Name == LocationNameEnum.CHG || l.Name == LocationNameEnum.NY)
        .Select(x => x.Id);
    var poc = session.QueryOver<TruckEntity>()
        .Where(Restrictions.Disjunction() // this takes care of the OR
            .Add(Subqueries.WhereProperty<TruckEntity>(x => x.CurrentLocation.Id).In(subQuery1))
            .Add(Subqueries.WhereProperty<TruckEntity>(x => x.NextDestination.Id).In(subQuery2))
        )
        .List<TruckEntity>();
