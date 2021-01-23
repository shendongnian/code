    using (var tx = session.BeginTransaction())
    {
        session.SaveOrUpdate(person);
        tx.Commit(); // throws here if there is conflict in a family
    }
