    try
    {
        rgNums[idx]=val;
    }
    catch (System.IndexOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
