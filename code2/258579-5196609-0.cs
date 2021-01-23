    Person personAlias = null;
    
    IList<Person> persons = 
            session.QueryOver<Person>(() => personAlias).WithSubquery
              .WhereExists(QueryOver.Of<Cat>()
                 .Where(c => c.Age > 5)
                 .And(c => c.Owner.Id == personAlias.Id)
                 .Select(c => c.Owner))
              .List<Person>();
