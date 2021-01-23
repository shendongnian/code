    var session = sessionFactory.OpenSession()
    using(var transaction = session.BeginTransaction()){
        var user = session.Get<User>(1);
        user.Name = "changed name";
        transaction.Commit();
    }
