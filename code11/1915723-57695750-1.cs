    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static async Task Main()
            {
                // Make your array of tasks.
                var factory = new CancellationTokenSource();
                var tasks = new List<Task<bool>>
                {
                    someTask(1000, false, factory.Token),
                    someTask(2000, false, factory.Token),
                    someTask(3000, true,  factory.Token),
                    someTask(4000, false, factory.Token),
                };
                while (tasks.Count > 0)
                {
                    var completed = await Task.WhenAny(tasks);
                    if (completed.Result) // Successful?
                    {
                        Console.WriteLine("A task completed successfully");
                        factory.Cancel();
                        return;
                    }
                    Console.WriteLine("A task completed unsuccessfully");
                    tasks.Remove(completed);
                }
                Console.WriteLine("No tasks completed successfully");
            }
            static async Task<bool> someTask(int delay, bool result, CancellationToken cancellation)
            {
                await Task.Delay(delay, cancellation);
                return result;
            }
        }
    }
