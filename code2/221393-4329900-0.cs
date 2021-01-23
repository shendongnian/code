    public interface IWorker
    {
        void DoWork(object anObject);
    }
    
    public enum WorkerState
    {
        Starting = 0,
        Started,
        Stopping,
        Stopped,
        Faulted
    }
    
    public class Worker : IWorker
    {
        public WorkerState State { get; set; }
    
        public virtual void DoWork(object anObject)
        {
            while (!_shouldStop)
            {
                // Do some work
                Thread.Sleep(5000);
            }
    
            // thread is stopping
            // Do some final work
        }
    
        public void RequestStop()
        {
            State = WorkerState.Stopping;
            _shouldStop = true;
        }
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        protected volatile bool _shouldStop;
    }
