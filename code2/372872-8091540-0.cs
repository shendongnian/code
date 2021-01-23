    public class MyConsumer
    {
        private readonly IEnumerable<ITask> tasks;
        public MyConsumer(IEnumerable<ITask> tasks)
        {
            this.tasks = tasks;
        }
        public void DoSomething()
        {
            foreach (var t in this.tasks)
            {
                // Do something with each t
            }
        }
    }
