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
            await WhenAllFastFail(Task.Delay(200), Task.Delay(2000).ContinueWith(t => throw new Exception("ouch")));
            Console.WriteLine("Hello World!");
        }
        public static Task WhenAllFastFail(params Task[] tasks)
        {
            // note: we don't really care about the generic type argument here.
            var tcs = new TaskCompletionSource<bool>();
            var remaining = tasks.Length;
            Action<Task> check = t =>
            {
                switch (t.Status)
                {
                    case TaskStatus.Faulted:
                        // we 'try' as some other task may beat us to the punch.
                        tcs.TrySetException(t.Exception);
                        break;
                    default:
                        // we can safely set here as no other task remains to run.
                        if (Interlocked.Decrement(ref remaining) == 0) tcs.SetResult(true);
                        break;
                }
            };
            foreach (var task in tasks)
            {
                task.ContinueWith(check, TaskContinuationOptions.ExecuteSynchronously);
            }
            return tcs.Task;
        }
    }
}
This doesn't handle task Cancellation gracefully as I don't know what your requirements are: should cancelling a single task prompt cancellation of the whole task? should it only happen if all tasks are cancelled?
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskcompletionsource-1?view=netframework-4.8
