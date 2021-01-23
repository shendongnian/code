    var crit = Session.CreateCriteria<X>()
        .CreateAlias("RefToY", "y")
        .CreateAlias("y.RefToZ", "z")
        .SetProjection(Projections.ProjectionList()
            .Add(Projections.Property("Id"))
            .Add(Projections.Property("z.data1"))
            .Add(Projections.Property("z.data2"))
            .Add(Projections.Property("z.data3")));
