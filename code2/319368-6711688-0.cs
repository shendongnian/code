    ISQLFunction sqlMyConcat= new VarArgsSQLFunction("", "+ ' ' +", " ")
     
    (...)
    .Add(Expression.Like(
        Projections.SqlFunction(
            sqlMyConcat, 
            NHibernateUtil.String,
            Projections.Property("FirstName"),
            Projections.Property("LastName")),
        Name,
        MatchMode.Anywhere))
    (...) 
