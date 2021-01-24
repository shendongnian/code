    try
    {
        await Task.Run(() =>
        {
            //Run task here...
        });
    }
    catch (AggregateException ex)
    {
        foreach (Exception inner in ex.InnerExceptions)
        {
             if (inner is MyCustomException)
             {
                 //todo smt..
                 throw inner;
             }
        }
    }
