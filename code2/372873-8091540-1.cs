    public CompositeTask : ITask
    {
        private readonly IEnumerable<ITask> tasks;
        public CompositeTask(IEnumerable<ITask> tasks)
        {
            this.tasks = tasks;
        }
        // Implement ITask by iterating over this.tasks
    }
