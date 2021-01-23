    ICriteria criteria = session.CreateCriteria(typeof(Person));
    criteria.SetProjection(
        Projections.Distinct(Projections.ProjectionList()
            .Add(Projections.Alias(Projections.Property("FirstName"), "FirstName"))
            .Add(Projections.Alias(Projections.Property("LastName"), "LastName"))));
    
    criteria.SetResultTransformer(
        new NHibernate.Transform.AliasToBeanResultTransformer(typeof(Person)));
    
    IList people = criteria.List();
