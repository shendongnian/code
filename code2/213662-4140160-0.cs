    try
    {
        throw new FaultException<DerivedClass2>(new DerivedClass2());
    }
    catch (FaultException fex)
    {
        bool handled = false;
        Type fexType = fex.GetType();
        if (fexType.IsGenericType && fexType.GetGenericTypeDefinition() == typeof(FaultException<>))
        {
            if (typeof(BaseClass1).IsAssignableFrom(fexType.GetGenericArguments()[0]))
            {
                object detail = fexType.GetProperty("Detail").GetValue(fex, null);
    
                // Use detail here.
    
                handled = true;
            }
        }
    
        if (!handled)
            throw; // Don't know how to handle. Re-throw.
    }
