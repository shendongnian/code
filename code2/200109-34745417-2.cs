    IEnumerable<int> TestCases3(Action<int, Exception> exceptionHandler)
    {
        foreach (var item in Enumerable.Range(0, 10))
        {
            int value = default(int);
            try
            {
                switch (item)
                {
                    case 2:
                    case 5:
                        throw new ApplicationException("This bit failed");
                    default:
                        value = item;
                        break;
                }
            }
            catch(Exception e)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler(item, e);
                    continue;
                }
                else
                    throw;
            }
            yield return value;
        }
    }
...
    foreach (var item in TestCases3(
        (int item, Exception ex) 
        => 
        Console.Out.WriteLine("Error on item: {0}, Exception: {1}", item, ex.Message)))
    {
        Console.Out.WriteLine(item);
    }
