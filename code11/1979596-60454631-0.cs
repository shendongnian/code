    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal static class Program
        {
            private static async Task Main()
            {
                var watcher = new Watcher();
                await watcher.Context.RaiseSomeEvent();
                Console.ReadKey();
            }
        }
        internal class Watcher
        {
            public Context Context { get; } = new Context();
            public Watcher()
            {
                Context.SomeEvent += async () =>
                {
                    Console.WriteLine($"Sleeping, current thread {Thread.CurrentThread.ManagedThreadId}");
                    await Task.Run(() => Thread.Sleep(1000));
                    Console.WriteLine($"Slept, current thread {Thread.CurrentThread.ManagedThreadId}");
                    throw new Exception();
                };
            }
        }
        internal class Context
        {
            //public event Action SomeEvent;
            public event Func<Task> SomeEvent;
            public async Task RaiseSomeEvent()
            {
                await SomeEvent?.Invoke();
            }
        }
    }
