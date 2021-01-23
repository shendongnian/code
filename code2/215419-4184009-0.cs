    public static void CheckMyEntity(IQueryable<ABCEty> _allABCs, MyEntity _myEntity)
    {
        foreach (var propertyInfo in _myEntity.GetType().GetProperties())
        {
            if (!String.IsNullOrEmpty(propertyInfo.GetValue(_myEntity, null).ToString()))
            {
                //access to modified closure
                PropertyInfo info = propertyInfo;
                _allABCs = _allABCs.Where(temp => temp.ABCMyEntitys.All(GenerateLambda(_myEntity, info)));
            }
        }
        var result = _allABCs.ToList();
    }
    
    private static Func<MyEntity, bool> GenerateLambda(MyEntity _myEntity, PropertyInfo propertyInfo)
    {
        var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
        var property = Expression.Property(instance, propertyInfo);
        var propertyValue = Expression.Constant(propertyInfo.GetValue(_myEntity, null));
        var equalityCheck = Expression.Equal(property, propertyValue);
        return Expression.Lambda<Func<MyEntity, bool>>(equalityCheck, instance).Compile();
    }
