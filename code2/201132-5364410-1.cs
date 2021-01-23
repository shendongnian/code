    public static class ParallelRunner
    {
        public static void Run(IEnumerable<IParallelFunction> parallelFunctions)
        {
            Parallel.ForEach(parallelFunctions, f => f.CacheResult());
        }
    }
