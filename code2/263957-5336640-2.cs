    static void Main(string[] args)
    {
        const int Jobs = 1000;
        const int Cores = 2;
        const int ConcurrentJobs = Cores + 1;
        const int Priorities = Cores + 3;
        DateTime startTime = new DateTime(2011, 3, 1, 0, 0, 0, 0);
        Console.WriteLine(string.Format("{0} Jobs x {1} Cores", Jobs, Cores));
        var timer = Stopwatch.StartNew();
        Console.WriteLine("Populating data");
        var jobs = new List<Job>();
        for (int jobId = 0; jobId < Jobs; jobId++)
        {
            var jobStart = startTime.AddHours(jobId / ConcurrentJobs).AddMinutes(jobId % ConcurrentJobs);
            jobs.Add(new Job() { Id = jobId, Priority = jobId % Priorities, Begin = jobStart, End = jobStart.AddHours(0.5) });
        }
        Console.WriteLine(string.Format("Completed in {0:n}ms", timer.ElapsedMilliseconds));
        timer.Reset();
        Console.WriteLine("Assigning Jobs to Cores");
        List<Assignment>[] assignments = new List<Assignment>[Cores];
        for (int core = 0; core < Cores; core++)
            assignments[core] = new List<Assignment>();
        Job[] lastJobs = new Job[Cores];
        var output = from k in (
                        from j in jobs
                        select Required(ref j, lastJobs, Cores)
                    )
                    where k != null
                    select k;
        
        List<Assignment> merged = new List<Assignment>();
        merged.AddRange(output);
        merged.Sort();
        Console.WriteLine(string.Format("Completed in {0:n}ms", timer.ElapsedMilliseconds));
        Console.WriteLine(string.Format("\nTotal Comparisons: {0:n}", Job.Iterations));
        Console.WriteLine("Any key to continue");
        Console.ReadKey();
    }
    private static Assignment Required(ref Job job, Job[] lastJobs, int Cores)
    {
        for (int core = 0; core < Cores; core++)
        {
            if (lastJobs[core] == null || !lastJobs[core].Overlaps(job))
            {
                // Assign directly if no last job or no overlap with last job
                lastJobs[core] = job;
                return new Assignment { Job = job, Core = core };
            }
            else if (job.Priority > lastJobs[core].Priority)
            {
                // Overlap and higher priority, so we replace
                Job temp = lastJobs[core];
                lastJobs[core] = job;
                job = temp; // Will try to later assign to other core
                return new Assignment { Job = job, Core = core };
            }
        }
        return null;
    }
