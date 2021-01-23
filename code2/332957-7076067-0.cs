    private BlockingCollection<Job> jobs = new BlockingCollection<Job>();
    private Task jobprocessor;
    public void StartWork() {
        timer.Start();
        jobprocessor = Task.Factory.StartNew(RunJobs);
    }
    public void EndWork() {
        timer.Stop();
        jobs.CompleteAdding();
        jobprocessor.Wait();
    }
    public void TimerTick() {
       var job = new Job();
       if (job.NeedsMoreWork())
           jobs.Add(job);
    }
    public void RunJobs() {
        var options = new ParallelOptions { MaxDegreeOfParallelism = 10 };
        Parallel.ForEach(jobs.GetConsumingPartitioner(), options,
                         job => job.DoSomething());
    }
