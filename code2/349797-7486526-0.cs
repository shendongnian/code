    var query = NHibernateHelper.Session.QueryOver<Blah>()
                      .Where(x => x.name = "");
    if(type == SomeType.A)
    {
        query = query.And(x => x.a == ...);
    }
    else
    {
        query = query.And(x => x.b == ... );
    }
