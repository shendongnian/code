    public MembershipProvider()
    {
      SessionProvider  = new DefaultSessionProvider();
    }
    
    public ISessionProvicer SessionProvider {get;set;}
    ...
    IList<User> Users;
            using (ISession sess = SessionProvider .GetSession())
