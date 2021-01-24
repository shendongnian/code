    public List<string> GetObjectsFromDb<T>(string columnName, Func<myLab02Entities1, T> entitySelector) where T : IEnumerable<T>
    {
        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
        var lambda = Expression.Lambda(Expression.Property(parameter, columnName), parameter);
        Expression<Func<T, string>> funcExpression = (Expression<Func<T, string>>) lambda;
        using (var mLEntities = new myLab02Entities1())
        {
            var cl = entitySelector(mLEntities).AsQueryable().Select(funcExpression).Distinct(); 
            List<string> searchRes = cl.AsEnumerable().ToList();
            return searchRes;
        }
    }
