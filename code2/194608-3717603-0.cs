    using (var session = factory.OpenSession())
    using (var tx = session.BeginTransaction())
    {
        //create and manipulate objects
        session.Save(newObjectToBePersisted);
        tx.Commit();
    }
