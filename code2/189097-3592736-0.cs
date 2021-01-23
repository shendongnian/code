    foreach ( var assembly in AppDommain.CurrentDomain.GetAssemblies() ) {
      foreach ( var type in assembly.GetTypes() ) {
        if ( type.Name == target ) {
          return type.FullName;
        }
      }
    }
