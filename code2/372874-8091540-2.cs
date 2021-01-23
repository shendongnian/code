    public class MyConsumer
    {
        private readonly ITask task;
        public MyConsumer(ITask task)
        {
            this.task = task;
        }
        public void DoSomething()
        {
            // Do something with this.task
        }
    }
