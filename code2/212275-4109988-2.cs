    if(!typeof(TEnum).IsEnum)
    {
     throw new ArgumentException(string.Format("{0} is not an Enum", typeof(TEnum)), typeof(EnumExtensionsInternal<>).GetGenericArguments()[0].Name);
    }
    ParameterExpression valueExpression = Expression.Parameter(typeof(TEnum));
    ParameterExpression flagExpression = Expression.Parameter(typeof(TEnum));
    ParameterExpression flagValueVariable = Expression.Variable(Type.GetTypeCode(typeof(TEnum)) == TypeCode.UInt64 ? typeof(ulong) : typeof(long));
    Expression<Func<TEnum, TEnum, bool>> lambdaExpression = Expression.Lambda<Func<TEnum, TEnum, bool>>(
      Expression.Block(
        new[] { flagValueVariable },
        Expression.Assign(
          flagValueVariable,
          Expression.Convert(
            flagExpression,
            flagValueVariable.Type
          )
        ),
        Expression.Equal(
          Expression.And(
            Expression.Convert(
              valueExpression,
              flagValueVariable.Type
            ),
            flagValueVariable
          ),
          flagValueVariable
        )
      ),
      valueExpression,
      flagExpression
    );
    return lambdaExpression.Compile();
