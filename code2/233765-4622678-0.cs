    DetachedCriteria sum = DetachedCriteria.For(typeof(MasterAsset), "asset2")
                      .SetProjection(Projections.Sum("PhysicCondition"));
    Session.CreateCriteria(typeof(MasterAsset), "asset1")
              .SetProjection(Projections.ProjectionList().Add(Projections.Property("IDMasterAsset"), "IDAsset"))
              .Add(Subqueries.PropertyLt("PhysicCondition", sum))
              .AddOrder(Order.Asc("IDAsset"))
              .List();     
