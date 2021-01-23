    // [1] - Class is responsible for generating complex data sets and 
    // adding them to processing queue
    class EnqueueWorker
    {
        //generate data and add to queue
        internal void ParrallelEnqueue(ConcurrentQueue<ComplexDataSet> resultQueue)
        {
            Parallel.For(1, 10000, (i) =>
            {
                ComplexDataSet cds = GenerateData(i);
                resultQueue.Enqueue(cds);
    
            });
        }
    
        //generate data
        ComplexDataSet GenerateData(int i)
        {
            return new ComplexDataSet();
        }
    }
