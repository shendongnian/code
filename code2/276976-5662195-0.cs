    var list = session.QueryOver<Store>()
        .Where(s => s.Name.IsLike("My", MatchMode.Anywhere))
        .OrderBy(NHibernate.Criterion.Projections.Conditional(
            NHibernate.Criterion.Restrictions.Like(
                NHibernate.Criterion.Projections.Property<Store>(s => s.Name), "My",
                    MatchMode.Start),
                NHibernate.Criterion.Projections.Constant(0),
                NHibernate.Criterion.Projections.Constant(1))).Asc
        .ThenBy(s => s.Name).Asc
        .List();
