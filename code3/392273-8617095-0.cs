    static class CriticalTasks
    {
        static HashSet<Task> tasks = new HashSet<Task>();
 
        public static void Add(Task t)
        {
            tasks.Add(t);
        }
        public static void WaitOnExit()
        {
            // filter, I'm not sure if Wait() on a canceled|completed Task would be OK
            var waitfor = tasks.Where(t => t.Status == TaskStatus.Running).ToArray();
            Task.WaitAll(waitfor, 5000);
        }
    }
