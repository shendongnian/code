    public MethodInfo GetMethodFromEnumerable(string methodName, params Func<MethodInfo, bool>[] filters)
            {
                var methods = typeof( Enumerable )
                    .GetMethods( BindingFlags.Static | BindingFlags.Public )
                    .Where( mi => mi.Name == methodName );
    
                methods = filters.Aggregate( methods, (current, filter) => current.Where( filter ) );
    
                return methods.First( );
            }
    
            public MethodInfo WhereMethod(Type collectionType)
            {
                // Get the Func<T,bool> version
                var getWhereMethod = GetMethodFromEnumerable( "Where",
                                        mi => mi.GetParameters( )[1].ParameterType.GetGenericArguments( ).Count( ) == 2 );
    
                return getWhereMethod.MakeGenericMethod( collectionType );
            }
    
            public MethodInfo CountMethod(Type collectionType)
            {
                var getCountMethod = GetMethodFromEnumerable( "Count" ); // There can be only one
    
                return getCountMethod.MakeGenericMethod( collectionType );
            }
