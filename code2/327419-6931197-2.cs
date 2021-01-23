    class ComplexDataSet { }
    
    class Program
    {
        //processing queueu - [2]
        private static ConcurrentQueue<ComplexDataSet> processingQueue;
    
        static void Main(string[] args)
        {
            // create new processing queue - single instance for whole app
            processingQueue = new ConcurrentQueue<ComplexDataSet>();
    
            //enqueue worker
            Task enqueueTask = Task.Factory.StartNew(() =>
                {
                    EnqueueWorker enqueueWorker = new EnqueueWorker();
                    enqueueWorker.ParrallelEnqueue(processingQueue);
                });
    
            //dequeue worker
            Task dequeueTask = Task.Factory.StartNew(() =>
            {
                DequeueWorker dequeueWorker = new DequeueWorker();
                dequeueWorker.ParrallelDequeue(processingQueue);
            });            
        }
    }
