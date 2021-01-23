    var availableJobs = new List<int>(... jobs here ...);
    var usedJobs = HashSet<int>();
    var selectedJobs = new Dictionary<int,int>(); // keyed by employee #
    for (int ww = 0; ww < preference.Count(); ++ww)
    {
        // this will throw an exception if strict ordering is unsolvable
        try
        {
            // Remove the try...catch if job cannot be 0 and use FirstOrDefault
            int job = preference[ww].First(jj => !usedJobs.Contains(jj));
            selectedJobs.Add(ww, job);
            usedJobs.Add(job);
        }
        catch(InvalidOperationException ioe)
        {
            Console.WriteLine("Cannot allocate job code to worker: {0}", ww);
            Console.WriteLine("No job preference matches.");
            Console.WriteLine("    Job codes avaliable");
            Console.WriteLine("    -------------------");
            foreach (var jobCode in availableJobs.Except(usedJobs))
            {
                 Console.WriteLine("{0}", jobCode);
            }
            break;
        }
    }
    if (selectedJobs.Count() == preference.Count())
    {
        // jobs have been assigned per worker
    }
