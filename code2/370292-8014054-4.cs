    public static IList<T> CreateInstances<T>( this Assembly assembly )
    {
         var query = from type in assembly.GetTypes().Where( t => typeof(T).IsAssignableFrom( t ) && typeof(T) != t ) 
                     where type.IsClass && ! type.IsAbstract && type.GetConstructor( Type.EmptyTypes ) != null 
                     select (T) Activator.CreateInstance( type );
         return query.ToList();
    }    
