    public static bool IsSet(this Colour states, Colour state)
    {
        // By default if not OR'd
        if (states == state)
            return true;
    
        // Combined: One or more bits need to be set
        if( state == Colour.Orange )
            return 0 != (int)(states & state);
                
        // Non-combined: all bits need to be set
        return (states & state) == state;
    }
