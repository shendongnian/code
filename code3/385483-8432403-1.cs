    public IQueryable<ApplicationEntity> TestRepo()
    {
        var x = ContextFactory.GetContext()
        return 
            from q in x.MyColumn
            select q;
    }
