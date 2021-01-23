    public static bool HasMethod(this object objectToCheck, string methodName)
    {
        try
        {
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName) != null;
        }
        catch(AmbiguousMatchException)
        {
            // ambiguous means there is more than one result,
            // which means: a method with that name does exist
            return true;
        }
    } 
