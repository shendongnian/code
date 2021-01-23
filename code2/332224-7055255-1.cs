    try 
    {
        // throws FormatExcpetion
        System.Data.SqlTypes.SqlInt16 i = System.Data.SqlTypes.SqlInt16.Parse("test"); 
    }
    catch (FormatException)
    {
        // handle it
    }
    try 
    {
        // i will be set to 10
        System.Data.SqlTypes.SqlInt16 i = System.Data.SqlTypes.SqlInt16.Parse("10"); 
    }
    catch (FormatException)
    {
        // handle it
    }
