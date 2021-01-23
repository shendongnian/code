     public List<PeopleSearchList> GetPeople(string filter, string searchType, string searchOption)
        {
            IQueryable<Person> query = _context.People;
            PropertyInfo property = typeof (Person).GetProperty(searchType);
            MethodInfo method = typeof (string).GetMethod(searchOption, new[] {typeof (string)});
            query = query.Where(WhereExpression(property, method, filter));
            IQueryable<PeopleSearchList> resultQuery = query.Select(p => new PeopleSearchList
                                                                             {
                                                                                 Firstname = p.Firstname,
                                                                                 Group = p.Level.Year,
                                                                                 IdentityCode = p.IdentityCode,
                                                                                 LoanCount = p.Loans.Count(),
                                                                                 Surname = p.Surname
                                                                             }
                ).OrderBy(p => p.Surname);
            return resultQuery.ToList();
        }
     Expression<Func<Person, bool>> WhereExpression(PropertyInfo property, MethodInfo method, string filter)
        {
            var param = Expression.Parameter(typeof(Person), "o");
            var propExpr = Expression.Property(param, property);
            var methodExpr = Expression.Call(propExpr, method, Expression.Constant(filter));
            return Expression.Lambda<Func<Person, bool>>(methodExpr, param);
        }
