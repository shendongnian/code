    public static object ExtendedClassInstance<T>()
    {
        Type type = typeof( T );
        if ( !_wrappedTypes.Contains( type ) )
        {
            // Use RunSharp to create the type.
        }
    
        return Activator.CreateInstance( _wrappedTypes[ type ] );
    }
