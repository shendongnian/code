    public static void NotNull([NotNull] object? o)
    {
        if (o is null)   
        {
            throw new Exception("!!!");
        }
    }
