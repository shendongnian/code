    public void FromWebClientRequest(int[] ids);
    {
       IRepoType repoType = container.Resolve<IRepoType>();
       ILogger logger = container.Resolve<ILogger>();
       // remove LongRunning if your operations are not blocking (Ie. read file or download file  long running queries etc)
       // I'm assuming your sample code is the real thing, and you really not do much aside the Parallel.ForEach, so this probably should be removed and is here just as a sample
       Task.Factory.StartNew(() => DoSomeWorkInParallel(ids, repoType, logger), TaskCreationOptions.LongRunning);
    }
    private static void DoSomeWorkInParallel(int[] ids, IRepoType repository, ILogger logger)
    {
        // if there are blocking operations inside this loop you ought to convert it to tasks, and fine grain with the same method as above.
        // if nothing else in this method blocks then remove LongRunning from the caller thread
        Parallel.ForEach(ids, id=>{
                      // Some work will be done here...
                      // use repository
                 });
       logger.Log("finished all work");
    }
