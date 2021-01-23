    using(IDocumentSession session = _store.OpenSession())
    {
        MyDocument doc = session.Query<MyDocument>("ByProperty")
                                .Where(d => d.Property == value)
                                .Single();
    }
