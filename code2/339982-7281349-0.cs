    public static bool SomeMethod(IEnumerable<string> enumerable)
    {
        if (enumerable == null)
            throw new ArgumentNullException();
    
        // Manually perform an All, keeping track of if there are any elements
        bool anyElements = false;
        bool result = true;
    
        foreach (string item in enumerable)
        {
            anyElements = true;
            result = result && SomeBooleanMethod(item);
    
            // Can short-circuit here
            if (!result)
                break;
        }
    
        if (!anyElements)
            throw new ArgumentException();    // Empty sequence is invalid argument
    
        return result;
    }
