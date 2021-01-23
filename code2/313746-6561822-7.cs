    public void FromWebClientRequest(int[] ids);
    {
       IRepoType repoType = container.Resolve<IRepoType>();
       ILogger logger = container.Resolve<ILogger>();
       // remove LongRunning if your operations are not blocking (Ie. read file or download file etc)
       Task.Factory.StartNew(() => DoSomeWorkInParallel(ids, repoType, logger), TaskCreationOptions.LongRunning);
    }
    private static void DoSomeWorkInParallel(int[] ids, IRepoType repository, ILogger logger)
    {
        Parallel.ForEach(ids, id=>{
                      // Some work will be done here...
                      // use repository
                 });
       logger.Log("finished all work");
    }
