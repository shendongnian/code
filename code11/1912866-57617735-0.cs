 cs
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.TimeSpan;
namespace StackOverflowAnswers
{
    public class Q57572902
    {
        public void ProcessAllPendingWork()
        {
            var workers = new Action[] {Worker1, Worker2, Worker3};
            try
            {
                Task.WaitAll(workers.Select(Task.Factory.StartNew).ToArray());
                // ok
            }
            catch (AggregateException exceptions)
            {
                foreach (var ex in exceptions.InnerExceptions)
                {
                    Log.Error(ex);
                }
                // ko
            }
        }
        public void Worker1() => Thread.Sleep(FromSeconds(5)); // do something
        public void Worker2() => Thread.Sleep(FromSeconds(10)); // do something
        public void Worker3() => throw new NotImplementedException("error to manage"); // something wrong
    }
}
  [1]: https://docs.microsoft.com/it-it/dotnet/api/system.threading.tasks.task.waitall?view=netframework-4.0
