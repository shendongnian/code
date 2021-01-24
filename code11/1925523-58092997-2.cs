    private List<Type> CharacterTypes = new List<Type>();
    var types = Assembly.GetExecutingAssembly().GetTypes();
    foreach ( Type type in types )
      if ( type.IsSubclassOf(typeof(Character)) )
        CharacterTypes.Add(type);
