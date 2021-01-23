    using System;
    using System.Threading;
    using System.Linq;
     
    public class Task {
        ManualResetEvent _mre = new ManualResetEvent(false);
     
        public Task(Action action) {
            ThreadPool.QueueUserWorkItem((s) => {
                action();
                _mre.Set();
            });
        }
     
        public static void WaitAll(params Task[] tasks) {
            WaitHandle.WaitAll(tasks.Select(t => t._mre).ToArray());
        }
    }
