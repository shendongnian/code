        Expression<Func<Persons, bool>> expresionFinal = c => c.Active == true;
    
        if (DateBirth.HasValue)
                    {
                        Expression<Func<Persons, bool>> expresionDate = c => (EntityFunctions.TruncateTime(c.DateBirth) == DateBirth);
                        expresionFinal = PredicateBuilder.And(expresionFinal, expresionDate);
                    }
    
    IQueryable query = dataContext.Persons;
     query = query.Where(expresionFinal);
