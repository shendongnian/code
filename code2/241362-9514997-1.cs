    public static Colour UnSet(this Colour states, Colour state)
    {
        if ((int)states == 0)
            return states;
    
        if (states == state)
            return Colour.None;
    
        return states & ~state;
    }
