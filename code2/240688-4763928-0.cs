    using (var session = NHibernateHelper.OpenSession()) 
    using (var transaction = session.BeginTransaction()) 
    { 
        var c1 = session.Load<Category>(32768); 
        var toDelete = c1.Ps[0];
        c1.Ps.RemoveAt(0); 
        session.Delete(toDelete);
        transaction.Commit(); 
        //you shouldn't need to update the c1 object
    }
