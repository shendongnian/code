    Projections.GroupProperty(
        Projections.SqlFunction(new SQLFunctionTemplate(
                                    NHibernateUtil.Date,
                                    "dateadd(dd, 0, datediff(dd, 0, ?1))"),
                                NHibernateUtil.Date,
                                Projections.GroupProperty("IssueDateTime")))
