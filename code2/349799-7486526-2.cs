    var query = NHibernateHelper.Session.QueryOver<Blah>()
                      .Where(x => x.name = "");
    Expression<Func<Blah, bool>> typePredicate = null;
    if(type == SomeType.A)
    {
        typePredicate = x => x.a == ...;
    }
    else
    {
        typePredicate = x => x.b == ...;
    }
    query = query.Where(typePredicate);
    
