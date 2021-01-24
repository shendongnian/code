    Expression<Func<Persons, bool>> expresionFinal = c => c.Active;
    
        if (departments.Any())
                    {
                        Expression<Func<Persons, bool>> expresionDepartments = c => departments.Contains(p.department);
                        expresionFinal = PredicateBuilder.And(expresionFinal, expresionDepartments);
                    }
    
    IQueryable query = dataContext.Persons;
     query = query.Where(expresionFinal);
