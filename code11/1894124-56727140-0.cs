    using System;
    using System.Threading.Tasks;
    namespace ConsoleApp3
    {
        class Program
        {
            static Task Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                DoJob();
                var z = 3;
                Console.ReadLine();
                return Task.CompletedTask;
            }
            static Task DoJob()
            {
                var work1 = new WorkClass();
                var work2 = new WorkClass();
                var tcs = new TaskCompletionSource<bool>();
                Loop();
                return tcs.Task;
                void Loop()
                {
                    work1.DoWork(500).ContinueWith(t1 =>
                    {
                        if (t1.IsFaulted) { tcs.SetException(t1.Exception); return; }
                        work2.DoWork(1500).ContinueWith(t2 =>
                        {
                            if (t2.IsFaulted) { tcs.SetException(t2.Exception); return; }
                            if (true) { Loop(); } else { tcs.SetResult(true); }
                            // The 'if (true)' corresponds to the 'while (true)'
                            // of the original code.
                        });
                    });
                }
            }
        }
        public class WorkClass
        {
            public Task DoWork(int delayMs)
            {
                var x = 1;
                int y;
                return Task.Delay(delayMs).ContinueWith(t =>
                {
                    if (t.IsFaulted) throw t.Exception;
                    y = 2;
                });
            }
        }
    }
