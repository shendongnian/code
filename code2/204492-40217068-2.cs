        static Expression<Func<T, Object>> GetGroupBy<T>( string property )
        {
          var data = Expression.Parameter( typeof( T ), "data" );
          var dataProperty = Expression.PropertyOrField( data, property );
          var conversion = Expression.Convert( dataProperty, typeof( object ) );
          return Expression.Lambda<Func<T, Object>>( conversion, data );
        }
