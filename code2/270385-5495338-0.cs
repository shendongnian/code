    void example( Object target, string propertyName )
    {
        PropertyInfo info = typeof(target).GetProperty( propertyName );
    
        object value = info.GetValue( target, new object[] {} );
    }
