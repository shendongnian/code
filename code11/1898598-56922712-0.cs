    using (var context = new SomeContext())
    {
        IQueryable<SomeEntity> query = context.SomeEntities;
        if (var1 != null)
            query = query.Where(x => x.Field1 == var1);
        if (var2 != null)
            query = query.Where(x => x.Field2 == var2);
        // and so on
        // use the query somehow
    }
