    class Program
    {
        static void Main(string[] args)
        {
            foreach (var x in CallBackToEnumerable<int>(Scan))
                Console.WriteLine(x);
        }
        static IEnumerable<T> CallBackToEnumerable<T>(Action<Action<T>> functionReceivingCallback)
        {
            return Observable.Create<T>(o =>
            {
                // Schedule this onto another thread, otherwise it will block:
                Scheduler.Later.Schedule(() =>
                {
                    functionReceivingCallback(o.OnNext);
                    o.OnCompleted();
                });
                return () => { };
            }).ToEnumerable();
        }
        public static void Scan(Action<int> act)
        {
            for (int i = 0; i < 100; i++)
            {
                // Delay to prove this is working asynchronously.
                Thread.Sleep(100);
                act(i);
            }
        }
    }
