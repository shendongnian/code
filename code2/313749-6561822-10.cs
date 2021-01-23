    public void FromWebClientRequest(int[] ids);
    {
       IRepoType repoType = container.Resolve<IRepoType>();
       ILogger logger = container.Resolve<ILogger>();
       // remove LongRunning if your operations are not blocking (Ie. read file or download file  long running queries etc)
       // prefer fairness is here to try to complete first the requests that came first, so client are more likely to be able to be served "first come, first served" in case of high CPU use with lot of requests
       Task.Factory.StartNew(() => DoSomeWorkInParallel(ids, repoType, logger), TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
    }
    private static void DoSomeWorkInParallel(int[] ids, IRepoType repository, ILogger logger)
    {
        // if there are blocking operations inside this loop you ought to convert it to tasks with LongRunning
        // why this? to force more threads as usually would be used to run the loop, and try to saturate cpu use, which would be doing nothing most of the time
        // beware of doing this is you work on a non clustered database, since you can saturate it and have a bottleneck there :)
        Parallel.ForEach(ids, id=>{
                      // Some work will be done here...
                      // use repository
                 });
       logger.Log("finished all work");
    }
