csharp
using System;
using System.Threading;
using System.Threading.Tasks;
namespace stackoverflow
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();
            var arr = await WhenAllFastFail(
                Task.FromResult(42),
                Task.Delay(2000).ContinueWith<int>(t => throw new Exception("ouch")),
                Task.FromCanceled<int>(cts.Token));
            Console.WriteLine("Hello World!");
        }
        public static Task<TResult[]> WhenAllFastFail<TResult>(params Task<TResult>[] tasks)
        {
            // defensive copy.
            var defensive = tasks.Clone() as Task<TResult>[];
            var tcs = new TaskCompletionSource<TResult[]>();
            var remaining = defensive.Length;
            Action<Task> check = t =>
            {
                switch (t.Status)
                {
                    case TaskStatus.Faulted:
                        // we 'try' as some other task may beat us to the punch.
                        tcs.TrySetException(t.Exception.InnerException);
                        break;
                    case TaskStatus.Canceled:
                        // we 'try' as some other task may beat us to the punch.
                        tcs.TrySetCanceled();
                        break;
                    default:
                        // we can safely set here as no other task remains to run.
                        if (Interlocked.Decrement(ref remaining) == 0)
                        {
                            // get the results into an array.
                            var results = new TResult[defensive.Length];
                            for (var i = 0; i < tasks.Length; ++i) results[i] = defensive[i].Result;
                            tcs.SetResult(results);
                        }
                        break;
                }
            };
            foreach (var task in defensive)
            {
                task.ContinueWith(check, TaskContinuationOptions.ExecuteSynchronously);
            }
            return tcs.Task;
        }
    }
}
**Edit**: Unwraps AggregateException, Cancellation support, return array of results.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskcompletionsource-1?view=netframework-4.8
