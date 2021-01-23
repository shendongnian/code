    string Match(string str)
    {
        if( string.Length == 0 || str[0] == ')' ) 
        {
            return str;
        }
        if( str[0] == '(' )
        {           
            string closer = Match(str.SubString(1));
            // The original code has a hidden check for termination here!
            // If *closer was '\0', it would not enter the if
            // Let's keep that and avoid IndexOutOfRange.
            if( closer.Length > 0 && closer[0] == ')' )
            {
                    return Match(closer.SubString(1));
            }           
            // The original just restored the pointer to its initial state.
            // Since C# strings are immutable, we can just return the original string.
            return str;
        }
    
        return match(str.SubString(1));
    }
