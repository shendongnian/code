    var subquery = DetachedCriteria.For<Items>("q")
        .SetProjection(Projections.ProjectionList()
            .Add(Projections.GroupProperty("q.ChildId")))
        .Add(Restrictions.EqProperty("p.Price", Projections.Max("q.Price")))
        .Add(Restrictions.EqProperty("p.ChildId", "q.ChildId"));
    var query = DetachedCriteria.For<Items>("p")
        .Add(Subqueries.Exists(subquery));
