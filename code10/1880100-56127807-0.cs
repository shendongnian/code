    class Program
    {
        static void Main(string[] args)
        {
            Guid lastID = default(Guid);
            List<CancellableTask> cancellableTasks = new List<CancellableTask>();
            for (int i = 0; i < 10; i++)
            {
                CancellableTask task = new CancellableTask(() =>
                {
                    Console.WriteLine("New task!");
                    Thread.Sleep(3000);
                });
                cancellableTasks.Add(task);
                lastID = task.ID;
            }
            CancellableTask cancellableTask = cancellableTasks.FirstOrDefault(x => x.ID == lastID);
            if (cancellableTask != null)
            {
                cancellableTask.Cancel();
            }
        }
    }
    public class CancellableTask
    {
        public Guid ID { get; private set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }
        public Task Task { get; private set; }
        public CancellableTask(Action action)
        {
            CancellationTokenSource = new CancellationTokenSource();
            Task = Task.Run(action, CancellationTokenSource.Token);
            ID = Guid.NewGuid();
        }
        public void Cancel()
        {
            CancellationTokenSource.Cancel();
        }
    }
