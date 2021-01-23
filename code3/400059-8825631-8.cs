    using (var session = SessionManager.OpenSession())
    {
        // create an instrument repo
        IInstrumentRepo instruments = DAL.RepoFactory.CreateInstrumentRepo(session);
        var guitar = instruments.Find(i => i.Type == "Guitar");
        // create a customer repo
        ICustomerRepo customers = DAL.RepoFactory.CreateCustomerRepo(session);
        var cust = customers.Find(c => c.Name == "Mark")
             
        // do something -> changes will be persisted by NH when session is disposed
        cust.Instruments.Add(guitar);
    }
