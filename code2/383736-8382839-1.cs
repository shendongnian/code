    var FruitBaskets = session.QueryOver<FuitBasket>()
        .Where(b => b.Owner.ID == OwnerID
                        && b.ExpiryDate <= dateTO
                        && b.ExpiryDate >= dateFROM)
        .Fetch(x => x.BasketLiner).Eager
        .JoinAlias(b => b.Yoghurts, () => yoghurtAlias, JoinType.LeftOuterJoin)
        .List();
    
    var yoghurts = session.QueryOver<Store.Yoghurt>()
        .WhereRestrictionOn(y => y.Id).In(FruitBaskets.SelectMany(b => b.Yoghurts).Select(y = > y.Id).Distinct())
        .JoinAlias(y => y.Flavour, () => flavourAlias, JoinType.InnerJoin)
        .List();
    
    session.QueryOver<Store.Flavor>()
        .WhereRestrictionOn(f => f.Id).In(yoghurts.SelectMany(y => y.Flavors).Select(b = > f.Id).Distinct())
        .JoinAlias(f => f.Owners, () => ownersAlias, JoinType.LeftOuterJoin)
        .List();
