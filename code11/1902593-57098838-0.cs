    public Expression<Func<TEntity, bool>> GetPredicate(string methodName, string propertyName, string propertyValue)
    {
        var parameterExp = Expression.Parameter(typeof(TEntity), "type");
        var propertyExp = Expression.Property(parameterExp, propertyName);
        MethodInfo method = typeof(string).GetMethod(methodName, new[] { typeof(string) });
        if (method == null)
        {
            var containsMethods = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == methodName);
            foreach (var m in containsMethods)
            {
                if (m.GetParameters().Count() == 2)
                {
                    method = m;
                    break;
                }
            }
        }
        var someValue = Expression.Constant(propertyValue, typeof(string));
        var containsMethodExp = Expression.Call(propertyExp, method, someValue);
        return Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameterExp);
    }
    Licence licence = db.Licence.Where(GetPredicate("Contains", fieldName, fieldValue)).FirstOrDefault();
