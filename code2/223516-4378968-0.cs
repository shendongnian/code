    var wrappedUnderlyingType = wrapped.GetType().GetGenericArguments().Single();
    
    if (wrappedUnderlyingType.IsAssignableFrom(unwrapped.GetType()))
    {
       foo();
    }
