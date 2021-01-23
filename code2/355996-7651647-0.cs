    public class Job
    {
        public string JobInfo {get;set;}
        public Action<Job> Callback {get;set;}
    }
    
    public class MyHardwareService
    {
        Queue<Job> _jobs = new Queue<Job>();
        Thread _hardwareThread;
        ManualResetEvent _event = new ManualResetEvent(false);
    
        public MyHardwareService()
        {
            _hardwareThread = new Thread(WorkerFunc);
        }
    
        public void Enqueue(Job job)
        {
          lock (_jobs)
            _jobs.Enqueue(job);
    
           _event.Set();
        }
    
        public void WorkerFunc()
        {
            while(true)
            {
                 _event.Wait(Timeout.Infinite);
                 Job currentJob;
                 lock (_queue)
                 {
                    currentJob = jobs.Dequeue();
                 }
    
                 //invoke hardware here.
    
                 //trigger callback in a Thread Pool thread to be able
                 // to continue with the next job ASAP
                 ThreadPool.QueueUserWorkItem(() => job.Callback(job));
    
                if (_queue.Count == 0)
                  _event.Reset();
    
            }
        }
    }
