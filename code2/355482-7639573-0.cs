    public abstract class BaseTask
    {
        public void Run()
        {
            Result = RunInternal();
        }
    
        public ResultContainer Result { get; set; }
    
        protected abstract ResultContainer RunInternal();
    }
