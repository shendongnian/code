    public void FromWebClientRequest(int[] ids);
    {
       IRepoType repoType = container.Resolve<IRepoType>();
       ILogger logger = container.Resolve<ILogger>();
       ThreadPool.QueueUserWorkItem(delegate
                                         {
                                             DoSomeWorkInParallel(id, repoType, logger);
                                         });
    }
    private static void DoSomeWorkInParallel(int[] ids, IRepoType repository, ILogger logger)
    {
        Parallel.ForEach(id, id=>
                                        {
                                            Some work will be done here...
                                            var repo = repository;
                                        });
       logger.Log("finished all work");
    }
