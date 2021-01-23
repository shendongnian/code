    static Int32 ToLower(Int32 c)
    {
        // Convert UTF-32 character to a UTF-16 String.
        var strC = Char.ConvertFromUtf32(c);
        
        // Casing rules depends on the culture.
        // Consider using ToLowerInvariant().
        var lower = strC.ToLower();
        // Convert the UTF-16 String back to UTF-32 character and return it.
        return Char.ConvertToUtf32(lower, 0);
    }
