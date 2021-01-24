    // Expression to construct: (Employee parameter) => parameter.GetPropertyValue(searchField).Contains(SearchValue)
    var parameter = Expression.Parameter(typeof(Employee));
    var employeePropertyValue = Expression.Property(parameter, searchField);
    var constainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
    var contains = Expression.Call(employeePropertyValue, containsMethod, Expression.Constant(searchString));
    var whereCondition = (Expression<Func<Employee, bool>>)Expression.Lambda(contains, parameter);
    // filtering
    employees = employees.Where(whereCondition);
