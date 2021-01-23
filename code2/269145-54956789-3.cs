    Type type = GetTypeWhomISuspectMightBeAGenericSignal();
    
    PropertyInfo secretProperty = type.GetProperty("Id", BindingFlags.NonPublic | BindingFlags.Instance);
    
    Type SpecificGenericType = secretProperty.DeclaringType; //This is the trick
    
    bool IsMyTypeInheriting = SpecificGenericType.IsGenericType && SpecificGenericType.GetGenericTypeDefinition() == typeof(Signal<>); //This way we are getting the genericTypeDefinition and comparing it to any other genericTypeDefinition of the same argument length.
