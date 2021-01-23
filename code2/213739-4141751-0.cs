    public static void Assign(object value, ref bool variable)
    {
        if (value == null) return;
    
        // We're assuming that a valid value will always be a string.  If this is not the
        // case, then we need to handle other types
        string valueString = value as string;
    
        bool result;
        if (bool.TryParse(valueString, out result))
        {
            variable = result;
        }
    }
