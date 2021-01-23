    foreach ( FieldInfo field in this.GetType() )
    {
      if ( field.FieldType.IsGenericType )
      {
        foreach ( Type param in field.FieldType.GetGenericArguments() )
        {
          if ( param.Name == soughtType )
          {
            return field.Name;
          }
        }
      }
    }
