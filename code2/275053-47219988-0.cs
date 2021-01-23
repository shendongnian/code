    using System;
    using System.Threading.Tasks;
    
    namespace MyNameSpace
    {
        public sealed class AsyncManager : IAsyncManager
        {
            private Action<Task> DefaultExeptionHandler = t =>
            {
                try { t.Wait(); }
                catch { /* Swallow the exception */ }
            };
    
            public Task Run(Action action, Action<Exception> exceptionHandler = null)
            {
                if (action == null) { throw new ArgumentNullException(nameof(action)); }
    
                var task = new Task(action);
    
                Action<Task> handler = exceptionHandler != null ?
                    new Action<Task>(t => exceptionHandler(t.Exception.GetBaseException())) :
                    DefaultExeptionHandler;
    
                var continuation = task.ContinueWith(handler,
                    TaskContinuationOptions.ExecuteSynchronously
                    | TaskContinuationOptions.OnlyOnFaulted);
                task.Start();
    
                return continuation;
            }
        }
    }
