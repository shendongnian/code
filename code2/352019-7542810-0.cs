    switch (Type.GetTypeCode(type))
    {
        case TypeCode.Int32:
            // It's an int
            break;
    
        case TypeCode.String:
            // It's a string
            break;
    
        // Other type code cases here...
    
        default:
            // Fallback to using if-else statements...
            if (type == typeof(MyCoolType))
            {
                // ...
            }
            else if (type == typeof(MyOtherType))
            {
                // ...
            } // etc...
    }
