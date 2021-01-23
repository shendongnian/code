    Parallel.Invoke(
        () =>
        {
           string region1ReturnMessage = ProcessMessage(...);
           Logger.Log(region1ReturnMessage);
        },
        () =>
        {
           string region2ReturnMessage = ProcessMessage(...);
           Logger.Log(region2ReturnMessage);
        });
