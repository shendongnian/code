    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static async Task Main()
            {
                // Make your array of tasks.
                var tasks = new List<Task<bool>>
                {
                    someTask(1000, false),
                    someTask(2000, false),
                    someTask(3000, true),
                    someTask(4000, false),
                };
                while (tasks.Count > 0)
                {
                    var completed = await Task.WhenAny(tasks);
                    if (completed.Result) // Successful?
                    {
                        Console.WriteLine("A task completed successfully");
                        return;
                    }
                    Console.WriteLine("A task completed unsuccessfully");
                    tasks.Remove(completed);
                }
                Console.WriteLine("No tasks completed successfully");
            }
            static async Task<bool> someTask(int delay, bool result)
            {
                await Task.Delay(delay);
                return result;
            }
        }
    }
