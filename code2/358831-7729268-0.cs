    List<string> StringList; //Populated in previous code
    Type[] assemblyTypes = RandomAssembly.GetTypes();
    Dictionary<String,Type> typesHash = new Dictionary<String,Type>();
    foreach ( Type type in assemblyTypes ) {
      typesHash.Add( type.Name, type );
    }
    
    foreach (String name in StringList)
    {                               
      Type type = null;
      if ( typesHash.TryGetValue( name, out type ) ) {
        // do something with type
      }
    }
