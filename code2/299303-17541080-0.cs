    private static Expression<Func<T, bool>> CreateLike<T>( PropertyInfo prop, string value )
    {
        var parameter = Expression.Parameter( typeof( T ) );
        Expression instanceExpression = Expression.MakeMemberAccess( parameter, prop );            
        if( prop.PropertyType != typeof( System.String ) )
        {
            var cast = Expression.Convert( instanceExpression, typeof( double? ) );
            MethodInfo toString = typeof( SqlFunctions ).GetMethods().First( m => m.Name == "StringConvert" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof( double? ) );
            instanceExpression = Expression.Call( toString, cast );                
        }
        var like = Expression.Call( instanceExpression, "Contains", null, Expression.Constant( value, typeof( string ) ) );
        return Expression.Lambda<Func<T, bool>>( like, parameter );
    }
