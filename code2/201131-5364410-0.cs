    public class ParallelFunction<T> : IParallelFunction
    {
        private readonly Func<T> function;
        public ParallelFunction(Func<T> function)
        {
            this.function = function;
        }
    
        public void CacheResult()
        {
            Data = function();
        }
    
        public T Data { get; private set; }
    }
