    Type type = GetTypeWhomISuspectMightBeAGenericSignal();
    
    PropertyInfo secretProperty = type.GetProperty("Id", BindingFlags.NonPublic | BindingFlags.Instance);
    
    Type SpecificGenericType = secretProperty.DeclaringType; //This is the trick
    
    bool IsMyTypeInheriting = secretProperty != null && SpecificGenericType.IsAssignableFrom(type); //IsAssignable will now work because we are not dealing with incomplete generic types but a specific generic type.
