    session.QueryOver<Lfee_Exc>()
        .Where(Restrictions.In(Projections.SqlFunction(
                                  "upper", NHibernateUtil.String,
                                   Projections.Property<Lfee_Exc>(x => x.FirstName)),
                               ListOfFirstNames))
