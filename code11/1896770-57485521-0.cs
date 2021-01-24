using ComposableAsync;
using RateLimiter;
using System;
using System.Threading.Tasks;
namespace RateLimiterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Log("Starting tasks ...");
            var constraint = TimeLimiter.GetFromMaxCountByInterval(1, TimeSpan.FromSeconds(0.5));
            var tasks = new[]
            {
                DoWorkAsync("Task1", constraint),
                DoWorkAsync("Task2", constraint),
                DoWorkAsync("Task3", constraint),
                DoWorkAsync("Task4", constraint)
            };
            Task.WaitAll(tasks);
            Log("All tasks finished.");
            Console.ReadLine();
        }
        static void Log(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff ") + message);
        }
        static async Task DoWorkAsync(string name, IDispatcher constraint)
        {
            await constraint;
            Log(name + " started");
            await Task.Delay(750);
            Log(name + " finished");
        }
    }
}
Sample output:
>**10:03:27.121** Starting tasks ...  
>**10:03:27.154** Task1 started  
>**10:03:27.658** Task2 started  
>**10:03:27.911** Task1 finished  
>**10:03:28.160** Task3 started  
>**10:03:28.410** Task2 finished  
>**10:03:28.680** Task4 started  
>**10:03:28.913** Task3 finished  
>**10:03:29.443** Task4 finished  
>**10:03:29.443** All tasks finished.
If you change the constraint to allow maximum two tasks per second (`var constraint = TimeLimiter.GetFromMaxCountByInterval(2, TimeSpan.FromSeconds(1));`), which is not the same as one per half a second, then the output could be like:
>**10:06:03.237** Starting tasks ...  
>**10:06:03.264** Task1 started  
>**10:06:03.268** Task2 started  
>**10:06:04.026** Task2 finished  
>**10:06:04.031** Task1 finished  
>**10:06:04.275** Task3 started  
>**10:06:04.276** Task4 started  
>**10:06:05.032** Task4 finished  
>**10:06:05.032** Task3 finished  
>**10:06:05.033** All tasks finished.
Note that the current version of Rate Limiter targets .NETFramework 4.7.2+ or .NETStandard 2.0+.
  [1]: https://apisyouwonthate.com/blog/what-is-api-rate-limiting-all-about
  [2]: https://github.com/David-Desmaisons/RateLimiter
  [3]: https://www.nuget.org/packages/RateLimiter/
