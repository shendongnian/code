    var q = _session.QueryOver<Event>()
                    .Select(Projections.Max(Projections.SqlFunction(
                            "addseconds",
                            NHibernateUtil.DateTime,
                            Projections.Property<Event>(y => y.DurationInSeconds),
                            Projections.Property<Event>(y => y.StartTime))))
                    .SingleOrDefault<DateTime>();
