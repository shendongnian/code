    IMultipleResults result = dc.FunkyStoredProcedure(1,2,3);
    try
    {
        var ints = result.GetResult<int>();
        DoStuffWithIntegerResults(ints);
    }
    catch(SystemException)
    {
        var dates = result.GetResult<DateTime>();
        DoStuffWithDateResults(dates);
    }
