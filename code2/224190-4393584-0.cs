    IList results = Session.CreateCriteria(typeof(Record), "record")
        .SetProjection(Projections.ProjectionList()
            .Add(Projections.SqlGroupProjection("CONVERT(date, {alias}.[IssueDatetime]) AS [DateVal]", "CONVERT(date, {alias}.[IssueDatetime])", new[] { "DateVal" }, new IType[] { NHibernateUtil.Date }))
            .Add(Projections.Sum("Tax"), "TotalFare"))
        .List();
