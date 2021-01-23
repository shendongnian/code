    public T UnProxyObjectAs<T>(object obj)
    {
        return Session.GetSessionImplementation().PersistenceContext.Unproxy(obj) as T;
    }
    
    var derived = UnProxyObjectAs<DerivedClass>(myClass);
