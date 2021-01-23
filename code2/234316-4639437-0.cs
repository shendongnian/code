    class MyPeriodicTasks : PeriodicMultiple
    {
        // The first task will start 30 seconds after this class is instantiated and started:
        protected override TimeSpan FirstInterval { get { return TimeSpan.FromSeconds(30); } }
        public MyPeriodicTasks()
        {
            Tasks = new[] {
                new Task { Action = task1, MinInterval = TimeSpan.FromMinutes(5) },
                new Task { Action = task2, MinInterval = TimeSpan.FromMinutes(15) },
            };
        }
        private void task1() { /* code that gets executed once every 5 minutes */ }
        private void task2() { /* code that gets executed once every 15 minutes */ }
    }
