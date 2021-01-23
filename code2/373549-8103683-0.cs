    using (var session = sessionFactory.OpenSession()) { 
        using (var sqlTrans = session.BeginTransaction()) { 
            ICriteria criteria = session.CreateCriteria(typeof(Foo)); 
            criteria.SetTimeout(5); //Here is the specified command timout, eg: property SqlCommand.CommandTimeout 
            Foo fooObject = session.Load<Foo>(primaryKeyIntegerValue, LockMode.Force); 
            session.Lock(fooObject, LockMode.Upgrade); <-- Try this line
            session.SaveOrUpdate(fooObject); 
            sqlTrans.Commit(); 
        } 
    }   
