    // Meaningful common ancestor for the working classes.
    interface IWorker
    {
       object DoWork();
    }
    // Generic abstract base class for working classes implementations.
    abstract WorkerImpl<TResult> : IWorker
    {
       public abstract TResult DoWork();
       object IWorker.DoWork()
       {
          return DoWork(); // calls TResult DoWork();
       }
    }
    // Concrete working class, specialized to deal with decimals.
    class ComputationWorker : WorkerImpl<decimal>
    {
        override decimal DoWork()
        {
           decimal res;
           // Do lengthy stuff...
           return res;
        }
    }
