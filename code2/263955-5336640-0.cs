    public class Job
    {
        public static long Iterations;
        public int Id;
        public int Priority;
        public DateTime Begin;
        public DateTime End;
        public bool Overlaps(Job other)
        {
            Iterations++;
            return this.End > other.Begin && this.Begin < other.End;
        }
    }
    public class Assignment : IComparable<Assignment>
    {
        public Job Job;
        public int Core;
        #region IComparable<Assignment> Members
        public int CompareTo(Assignment other)
        {
            return Job.Begin.CompareTo(other.Job.Begin);
        }
        #endregion
    }
    class Program
    {
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
            foreach (Job j in jobs)
            {
                Job job = j;
                bool assigned = false;
                for (int core = 0; core < Cores; core++)
                {
                    if (lastJobs[core] == null || !lastJobs[core].Overlaps(job))
                    {
                        // Assign directly if no last job or no overlap with last job
                        lastJobs[core] = job;
                        assignments[core].Add(new Assignment { Job = job, Core = core });
                        assigned = true;
                        break;
                    }
                    else if (job.Priority > lastJobs[core].Priority)
                    {
                        // Overlap and higher priority, so we replace
                        Job temp = lastJobs[core];
                        lastJobs[core] = job;
                        job = temp; // Will try to later assign to other core
                        assignments[core].Add(new Assignment { Job = job, Core = core });
                        assigned = true;
                        break;
                    }
                }
                if (!assigned)
                {
                    // TODO: What to do if not assigned? Your code seems to just ignore them
                }
            }
            List<Assignment> merged = new List<Assignment>();
            for (int core = 0; core < Cores; core++)
                merged.AddRange(assignments[core]);
            merged.Sort();
            Console.WriteLine(string.Format("Completed in {0:n}ms", timer.ElapsedMilliseconds));
            timer.Reset();
            Console.WriteLine(string.Format("\nTotal Comparisons: {0:n}", Job.Iterations));
            Job.Iterations = 0; // Reset to count again
            {
                IEnumerable<Assignment> assignments2 = null;
                for (int core = 0; core < Cores; core++)
                {
                    // avoid modified closures by creating local variables
                    int localCore = core;
                    var localAssignments = assignments2;
                    // Step 1: Determine the remaining jobs
                    var remainingJobs = localAssignments == null ?
                                                        jobs :
                                                        from j in jobs where !(from a in localAssignments select a.Job).Contains(j) select j;
                    // Step 2: Assign the top priority job in any time-slot to the core
                    var assignmentsForCore = from s1 in remainingJobs
                                             where
                                                 (from s2 in remainingJobs
                                                  where s1.Overlaps(s2)
                                                  orderby s2.Priority
                                                  select s2).First().Equals(s1)
                                             select new Assignment { Job = s1, Core = localCore };
                    // Step 3: Accumulate the results (unfortunately requires a .ToList() to avoid massive over-joins)
                    assignments2 = assignments2 == null ? assignmentsForCore.ToList() : assignments2.Concat(assignmentsForCore.ToList());
                }
                // This is where I'd like to Execute the query one single time across all cores, but have to do intermediate steps to avoid massive-over-joins
                assignments2 = assignments2.ToList();
                Console.WriteLine(string.Format("Completed in {0:n}ms", timer.ElapsedMilliseconds));
                Console.WriteLine("\nJobs:");
                foreach (var job in jobs.Take(20))
                {
                    Console.WriteLine(string.Format("{0}-{1} Id {2} P{3}", job.Begin, job.End, job.Id, job.Priority));
                }
                Console.WriteLine("\nAssignments:");
                foreach (var assignment in assignments2.OrderBy(a => a.Job.Begin).Take(10))
                {
                    Console.WriteLine(string.Format("{0}-{1} Id {2} P{3} C{4}", assignment.Job.Begin, assignment.Job.End, assignment.Job.Id, assignment.Job.Priority, assignment.Core));
                }
                if (merged.Count != assignments2.Count())
                    System.Console.WriteLine("Difference count {0}, {1}", merged.Count, assignments2.Count());
                for (int i = 0; i < merged.Count() && i < assignments2.Count(); i++)
                {
                    var a2 = assignments2.ElementAt(i);
                    var a = merged[i];
                    if (a.Job.Id != a2.Job.Id)
                        System.Console.WriteLine("Difference at {0} {1} {2}", i, a.Job.Begin, a2.Job.Begin);
                    if (i % 100 == 0) Console.ReadKey();
                }
            }
            
            Console.WriteLine(string.Format("\nTotal Comparisons: {0:n}", Job.Iterations));
            Console.WriteLine("Any key to continue");
            Console.ReadKey();
        }
    }
