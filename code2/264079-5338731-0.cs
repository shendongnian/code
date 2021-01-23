    .Add(Restrictions.Like(Projections.SqlFunction("concat",
            NHibernateUtil.String,
            Projections.Property("Firstname"),
            Projections.Constant(" "),
            Projections.Property("Surname")),
        searchString, MatchMode.Anywhere))
