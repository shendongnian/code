    // untested
    static class CriticalTasks
    {
        static HashSet<Task> tasks = new HashSet<Task>();
        static object locker = new object();
 
        // when starting a Task
        public static void Add(Task t)
        {
            lock(locker)
               tasks.Add(t);
        }
        // When a Tasks completes
        public static void Remove(Task t)
        {
            lock(locker)
               tasks.Remove(t);
        }
        // Having to call Remove() is not so convenient, this is a blunt solution. 
        // call it regularly
        public static void Cleanup()
        {
            lock(locker)
               tasks.RemoveWhere(t => t.Status != TaskStatus.Running);
        }
        // from Application.Exit() or similar. 
        public static void WaitOnExit()
        {
            // filter, I'm not sure if Wait() on a canceled|completed Task would be OK
            var waitfor = tasks.Where(t => t.Status == TaskStatus.Running).ToArray();
            Task.WaitAll(waitfor, 5000);
        }
    }
