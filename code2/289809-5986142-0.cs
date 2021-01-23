    class WorkProcessor
    {
        public Action<Action<WorkItem>> WorkScheduler { get; set; }
        public void ScheduleWork(WorkItem workItem)
        {
            WorkScheduler(ProcessWork);
        }
 
        public void ProcessWork(workItem)
        {
            //...
        }
    }
