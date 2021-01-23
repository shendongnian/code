    private void SomeMethod( ... )
    {
        string str = GetTextFile( ... ); // read text file into a string
        
        // 2nd param should include the space before and after the = sign.
        string updated = UpdateValue( str, "potato = ", 5000, 0 );
        
        UpdateTextFile( ... ); // update the original text file
    }
    
    /// <summary>
    /// Updates the value of all integer values in a string that
    /// are preceeded by the string to <param name="match"></param>.
    /// Uses recursion to update all values.
    /// </summary>
    /// <param name="original">Entire original string.</param>
    /// <param name="match">Phrase preceeding the value to update.</param>
    /// <param name="increaseBy">Amount to increase the variable by.</param>
    /// <param name="startIndex">Index of the original string to start looking
    /// for the <param name="match"></param> phrase. Index should always
    /// be 0 when calling method for first time. <param name="startIndex"></param> 
    /// will be updated automatically through recursion.
    /// </param>
    private static string UpdateValue( string original, string match, int increaseBy, int startIndex )
    {
        string skip = original.Substring( 0, startIndex );
        string fragment = original.Substring( startIndex );
    
        int start = fragment.IndexOf( match, StringComparison.OrdinalIgnoreCase );
        if( start == -1 )
        {
            return original;
        }
    
        start = start + match.Length;
    
        int end = fragment.IndexOf( ";", start );
    
        if( end == -1 )
        {
            return original;
        }
    
        string left = fragment.Substring( 0, start );
        
        string right = fragment.Substring( end );
    
        string value = fragment.Substring( start, end - start );
    
        int newValue = int.Parse( value ) + increaseBy;
    
        string str = skip + left + newValue + right;
    
        return UpdateValue( str, match, increaseBy, startIndex + end );
    }
