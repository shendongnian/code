    using (var session = sessionFactory.OpenSession()) {
        using (var sqlTrans = session.BeginTransaction()) {
    		ICriteria criteria = session.CreateCriteria<Foo>();
    		criteria.Add(Restrictions.Eq(fieldOnWhichYouWishToGetTheLock, fieldValue));
    		criteria.SetLockMode(LockMode.Upgrade);
    		criteria.SetTimeout(5);
    		Foo fooObject = (Foo)criteria.List<Foo>();
    		//Make the changes to foo object and save as usual.
        }
    }
