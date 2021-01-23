    var criteria = session.CreateCriteria<Parent>("p")
                            .Add(Restrictions.IsNotEmpty("p.Children"));
                        
    foreach (var name in namesToMatch)
    {
         criteria.Add(Subqueries.Exists(DetachedCriteria.For<Parent>("p2")
                                .SetProjection(Projections.Id())
                                .CreateAlias("p2.Children", "c")
                                .Add(Restrictions.Eq("c.Name", name))
                                .Add(Restrictions.EqProperty("p2.Id", "p.Id"))));
    }
