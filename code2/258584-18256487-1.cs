    using (ITransaction tx = session.BeginTransaction())
    {
        var evProject = session.Get<EVProject>("C0G");
    
        CollectionAssert.AreEquivalent(TestData._evProjectLedgers.ToList(), evProject.EVProjectLedgers.ToList());
    
        tx.Commit();
    }
