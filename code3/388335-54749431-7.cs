    void Test(IQueryProcessor p)
    {
        var query = new SomeQuery();
    
        //You can now call it like this:
        p.Process(query, x => x);
        //Instead of
        p.Process<SomeQuery, string>(query);
    }
