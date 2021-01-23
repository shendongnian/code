    public IQueryable<Person> Search(Dictionary<string, string> searchParams)
    {
        DBDataContext dc = new DBDataContext();
        var query = dc.Persons.Where(p => true); //do an 'empty predicate' because you want 'query' to be an iqueryable<Person> not a Table<Person>
        //build a list of the types of things you can filter on.
        var criteriaDefinitions = new Dictionary<string,Func<string,Expression<Func<Person,bool>>>>();
        criteriaDefinitions.Add("FirstName",s => p => p.FirstName == s);
        criteriaDefinitions.Add("LastName",s => p => p.LastName == s);
        //you can do operations other than just equals
        criteriaDefinitions.Add("EmailContains",s => p => p.Email.Contains(s));
        //you can even create expressions that integrate joins.
        criteriaDefinitions.Add("HasContactInCity",s => p => p.Contacts.Any(c => c.City == s));
        foreach (KeyValuePair<string, string> temp in searchParams)
        {
            //grab the correct function out of the dictionary
            var func = criteriaDefinitions[temp.Key];
            //evaluating the function will return an expression which can passed into the where clause.
            var expr = func(temp.Value);
            query = query.Where(expr);
        }
        return query;
    }
