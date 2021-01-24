using MassTransit.Util;
using System;
using System.Linq;
using System.Threading.Tasks;
//using System.Threading.Tasks.Schedulers;
namespace LimitedConcurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TaskSchedulerTest();
            test.Run();
        }
    }
    class TaskSchedulerTest
    {
        public void Run()
        {
            var scheduler = new LimitedConcurrencyLevelTaskScheduler(2);
            var taskFactory = new TaskFactory(scheduler);
            var tasks = Enumerable.Range(1, 2).Select(id => taskFactory.StartNew(() => DoWork(id)));
            Task.WaitAll(tasks.ToArray());
        }
        private async Task DoWork(int id)
        {
            Console.WriteLine($"Starting Work {id}");
            await HttpClientGetAsync();
            Console.WriteLine($"Finished Work {id}");
        }
        async Task HttpClientGetAsync()
        {
            await Task.Delay(2000);
        }
    }
}
https://medium.com/rubrikkgroup/understanding-async-avoiding-deadlocks-e41f8f2c6f5d
TLDR never call .result, which I'm sure .GetResult(); was doing
