    public void AddQuery(int personId, AddQueryViewModel queryModel)
    {
        if (queryModel == null)
           throw new ArgumentNullException("queryModel");
    
        // TODO: Validate queryModel, ensure everything is Ok, not tampered/invalid.
        using (var ctx = new DBContext) 
        {
            var person = ctx.Persons
                .Include( x => x.Queries )
                .Where( x => x.PersonId == personId )
                .Single();
    
            // TODO: Maybe check for duplicate query already on Person, etc.
            var query = new Query
            {
                // copy data from view model
            };
            person.Queries.Add(query);
            ctx.SaveChanges();
        }
    }
