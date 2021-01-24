    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp4
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                using (var delayedWorker = new DelayedWorker())
                {
                    delayedWorker.ProcessWithDelay(() => { Console.WriteLine("100"); }, TimeSpan.FromSeconds(5), out var cancellationId_1);
                    delayedWorker.ProcessWithDelay(() => { Console.WriteLine("200"); }, TimeSpan.FromSeconds(10), out var cancellationId_2);
                    delayedWorker.ProcessWithDelay(() => { Console.WriteLine("300"); }, TimeSpan.FromSeconds(15), out var cancellationId_3);
    
                    Cancel_3(delayedWorker, cancellationId_3);
    
                    Console.ReadKey();
                }
            }
    
            private static void Cancel_3(DelayedWorker delayedWorker, Guid cancellationId_3)
            {
                Task.Run(() => { delayedWorker.Abort(cancellationId_3); }).Wait();
            }
    
            internal sealed class DelayedWorker : IDisposable
            {
                private readonly object _locker = new object();
                private readonly object _disposeLocker = new object();
                private readonly IDictionary<Guid, (Task task, CancellationTokenSource cts)> _tasks = new Dictionary<Guid, (Task task, CancellationTokenSource cts)>();
                private bool _disposing;
    
                public void ProcessWithDelay(Action action, TimeSpan waitBeforeExecute, out Guid cancellationId)
                {
                    Console.WriteLine("Creating delayed action...");
                    CancellationTokenSource tempCts = null;
                    CancellationTokenSource cts = null;
    
                    try
                    {
                        var id = cancellationId = Guid.NewGuid();
    
                        tempCts = new CancellationTokenSource();
                        cts = tempCts;
    
                        var task = new Task(() => { Process(action, waitBeforeExecute, cts); }, TaskCreationOptions.LongRunning);
                        _tasks.Add(cancellationId, (task, cts));
                        tempCts = null;
    
                        task.ContinueWith(t =>
                        {
                            lock (_disposeLocker)
                            {
                                if (!_disposing)
                                {
                                    TryRemove(id);
                                }
                            }
                        }, TaskContinuationOptions.ExecuteSynchronously);
    
                        Console.WriteLine($"Created(cancellationId: {cancellationId})");
                        task.Start(TaskScheduler.Default);
                    }
                    finally
                    {
                        if (tempCts != null)
                        {
                            tempCts.Dispose();
                        }
                    }
                }
    
                private void Process(Action action, TimeSpan waitBeforeExecute, CancellationTokenSource cts)
                {
                    Console.WriteLine("Starting delayed action...");
                    cts.Token.WaitHandle.WaitOne(waitBeforeExecute);
                    if (cts.Token.IsCancellationRequested)
                    {
                        return;
                    }
    
                    lock (_locker)
                    {
                        Console.WriteLine("Performing action...");
                        action();
                    }
                }
    
                public bool Abort(Guid cancellationId)
                {
                    Console.WriteLine($"Aborting(cancellationId: {cancellationId})...");
    
                    lock (_locker)
                    {
                        if (_tasks.TryGetValue(cancellationId, out var value))
                        {
                            if (value.task.IsCompleted)
                            {
                                Console.WriteLine("too late");
                                return false;
                            }
    
                            value.cts.Cancel();
                            value.task.Wait();
    
                            Console.WriteLine("Aborted");
                            return true;
                        }
    
                        Console.WriteLine("Either too late or wrong cancellation id");
                        return true;
                    }
                }
    
                private void TryRemove(Guid id)
                {
                    if (_tasks.TryGetValue(id, out var value))
                    {
                        Remove(id, value.task, value.cts);
                    }
                }
    
                private void Remove(Guid id, Task task, CancellationTokenSource cts)
                {
                    _tasks.Remove(id);
    
                    Dispose(cts);
                    Dispose(task);
                }
    
                public void Dispose()
                {
                    lock (_disposeLocker)
                    {
                        _disposing = true;
                    }
    
                    if (_tasks.Count > 0)
                    {
                        foreach (var t in _tasks)
                        {
                            t.Value.cts.Cancel();
                            t.Value.task.Wait();
    
                            Dispose(t.Value.cts);
                            Dispose(t.Value.task);
                        }
    
                        _tasks.Clear();
                    }
                }
    
                private static void Dispose(IDisposable obj)
                {
                    if (obj == null)
                    {
                        return;
                    }
    
                    try
                    {
                        obj.Dispose();
                    }
                    catch (Exception ex)
                    {
                        //log ex
                    }
                }
            }
        }
    }
