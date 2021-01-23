    public void ListPropertiesOfType( object targetObject, Type propertyType ) {
      foreach( var foundProperty in targetObject.GetType( ).GetProperties( ).Where( p => p.PropertyType == propertyType ) ) {
        Console.WriteLine( "Name: {0}, Value: {1}", foundProperty.Name, foundProperty.GetValue( targetObject, null ) );
      }
    }
    ListPropertiesOfType(new Wrapper(), typeof(SomeClass))
    ListPropertiesOfType(new Wrapper(), typeof(SomeOtherClass))
