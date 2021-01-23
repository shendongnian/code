    Session.CreateCriteria<Customer>()
        .Add(Restrictions.Like(
        Projections.SqlFunction("concat",
                                NHibernateUtil.String,
                                Projections.Property("FirstName"),
                                Projections.Constant(" "),
                                Projections.Property("LastName")),
        "Bob Whiley",
        MatchMode.Anywhere))
