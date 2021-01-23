    public void FromWebClientRequest(int[] ids);
    {
       IRepoType repoType = container.Resolve<IRepoType>();
       ILogger logger = container.Resolve<ILogger>();
       ThreadPool.QueueUserWorkItem((o) => DoSomeWorkInParallel(ids, repoType, logger));
    }
    private static void DoSomeWorkInParallel(int[] ids, IRepoType repository, ILogger logger)
    {
        Parallel.ForEach(ids, id=>{
                      // Some work will be done here...
                      // use repository
                 });
       logger.Log("finished all work");
    }
