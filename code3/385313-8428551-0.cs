    var subquery = DetachedCriteria.For<Part>()
        .Add(Restrictions.EqProperty("Name", "part.Name"))  <-- part is the alias of the main query
        .SetProjection(Projections.Max("IssueNo"));
    var results = session.CreateCriteria<Part>("part")
        .Add(Restrictions.Eq("IsLive", true))
        .Add(Restrictions.Like("Name", teststring, MatchMode.Anywhere))
        .Add(Subqueries.Eq("IssueNo", subquery))
        .List();
