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
            object detail = ((dynamic)fex).Detail;
            if (detail is BaseClass1) // true for subclasses too!
            {
                // Use detail here.
            }
         
        }
        
        if (!handled)
            throw; // Don't know how to handle. Re-throw. 
    }
