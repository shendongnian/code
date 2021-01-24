    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace SO60066033
    {
        public class Program
        {
            static async Task Main(string[] args)
            {
                var someTasks = new Func<Task<int>>[]
                {
                    () => Task.FromResult(1),
                    () => Task.FromResult(2),
                    () => Task.FromResult(3),
                    () => Task.FromResult(4),
                };
                var results = someTasks.AwaitAll();
                await foreach (var result in results)
                    Console.WriteLine(result);
                var reversedTasks = someTasks.Reverse().ToList();
                var reversedResults = reversedTasks.AwaitAll();
                await foreach (var result in reversedResults)
                    Console.WriteLine(result);
            }
        }
        public static class TaskExtensions
        {
            public static async IAsyncEnumerable<T> AwaitAll<T>(this IEnumerable<Func<Task<T>>> tasks)
            {
                foreach (var task in tasks)
                    yield return await task();
            }
        }
    }
