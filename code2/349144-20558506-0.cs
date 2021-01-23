    internal class Program
    {
        private static void Main(string[] args)
        {
            var ct = new CancellationTokenSource();
 
            new Task(() => Console.WriteLine("Running...")).Repeat(ct.Token, TimeSpan.FromSeconds(1));
 
            Console.WriteLine("Starting. Hit Enter to Stop.. ");
            Console.ReadLine();
 
            ct.Cancel();
 
            Console.WriteLine("Stopped. Hit Enter to exit.. ");
            Console.ReadLine();
        }
    }
 
 
    public static class TaskExtensions
    {
        public static void Repeat(this Task taskToRepeat, CancellationToken cancellationToken, TimeSpan intervalTimeSpan)
        {
            var action = taskToRepeat
                .GetType()
                .GetField("m_action", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(taskToRepeat) as Action;
 
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (cancellationToken.WaitHandle.WaitOne(intervalTimeSpan))
                        break;
                    if (cancellationToken.IsCancellationRequested)
                        break;
                    Task.Factory.StartNew(action, cancellationToken);
                }
            }, cancellationToken);
        }
    }
