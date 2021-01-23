    User newUser = new User();
    Role newRole = new Role();
    newUser.AddRole(newRole);
    newRole.AddUser(newUser);
    using (NHibernate.ISession session = iSessionFactory.OpenSession())
    {
        using (NHibernate.ITransaction tran = session.BeginTransaction())
    	{
    		session.Save(newUser);
    		tran.Commit();
    	}
    }
