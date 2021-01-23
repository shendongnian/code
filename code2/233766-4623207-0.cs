    DetachedCriteria sum = DetachedCriteria.For(typeof(MasterAsset), "asset2")
                        .SetProjection(Projections.Sum("PhysicCondition"));
    
    DetachedCriteria count = DetachedCriteria.For(typeof(MasterAsset), "asset3")
                        .SetProjection(Projections.Count("PhysicCondition"));
    
    Session.CreateCriteria(typeof(MasterAsset), "asset1")
                        .SetProjection(Projections.ProjectionList()
                        .Add(Projections.Property("IDMasterAsset"), "IDAsset"))
                        .Add(Subqueries.PropertyLt("PhysicCondition", sum))
                        .Add(Subqueries.PropertyLe("PhysicCondition", count))
                        .AddOrder(Order.Asc("IDAsset"))
                        .List();
