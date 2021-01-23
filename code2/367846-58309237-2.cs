    public static DbType GetDbType(Type runtimeType)
    {
        var nonNullableType = Nullable.GetUnderlyingType(runtimeType);
        if (nonNullableType != null)
        {
            runtimeType = nonNullableType;
        }
    
        var templateValue = (Object)null;
        if (runtimeType.IsClass == false)
        {
            templateValue = Activator.CreateInstance(runtimeType);
        }
    
        var sqlParamter = new SqlParameter(parameterName: String.Empty, value: templateValue);
    
        return sqlParamter.DbType;
    }
