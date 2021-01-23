    public TheInheritor(TheArgument theArgument)
        : base(ConvertToId(theArgument))
    {
    }
    private static int ConvertToId(TheArgument theArgument)
    {
        if (theArgument == null)
        {
            throw new ArgumentNullException("theArgument");
        }
        return theArgument.Id;
    }
