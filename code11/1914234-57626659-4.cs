    public class WinformsApartment : IDisposable
    {
        readonly Thread _thread; // the STA thread
        readonly TaskScheduler _taskScheduler; // the STA thread's task scheduler
        readonly Task _threadEndTask; // to keep track of the STA thread completion
        readonly object _lock = new object();
        public TaskScheduler TaskScheduler { get { return _taskScheduler; } }
        public Task AsTask { get { return _threadEndTask; } }
        /// <summary>MessageLoopApartment constructor</summary>
        public WinformsApartment(Func<Form> createForm)
        {
            var schedulerTcs = new TaskCompletionSource<TaskScheduler>();
            var threadEndTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            // start an STA thread and gets a task scheduler
            _thread = new Thread(_ =>
            {
                try
                {
                    // handle Application.Idle just once
                    // to make sure we're inside the message loop
                    // and the proper synchronization context has been correctly installed
                    void onIdle(object s, EventArgs e)
                    {
                        Application.Idle -= onIdle;
                        // make the task scheduler available
                        schedulerTcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
                    };
                    Application.Idle += onIdle;
                    Application.Run(createForm());
                    threadEndTcs.TrySetResult(true);
                }
                catch (Exception ex)
                {
                    threadEndTcs.TrySetException(ex);
                }
            });
            async Task waitForThreadEndAsync()
            {
                // we use TaskCreationOptions.RunContinuationsAsynchronously
                // to make sure thread.Join() won't try to join itself
                Debug.Assert(Thread.CurrentThread != _thread);
                try
                {
                    await threadEndTcs.Task.ConfigureAwait(false);
                }
                finally
                {
                    _thread.Join();
                }
            }
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.IsBackground = true;
            _thread.Start();
            _taskScheduler = schedulerTcs.Task.Result;
            _threadEndTask = waitForThreadEndAsync();
        }
        // TODO: it's here for debugging leaks
        public static readonly WeakReference s_debugTaskRef = new WeakReference(null);
        /// <summary>shutdown the STA thread</summary>
        public void Dispose()
        {
            lock (_lock)
            {
                if (Thread.CurrentThread == _thread)
                    throw new InvalidOperationException();
                if (!_threadEndTask.IsCompleted)
                {
                    // execute Application.ExitThread() on the STA thread
                    var terminatorTask = Run(() => Application.ExitThread());
                    s_debugTaskRef.Target = terminatorTask; // TODO: it's here for debugging leaks
                    _threadEndTask.GetAwaiter().GetResult();
                }
            }
        }
        /// <summary>Task.Factory.StartNew wrappers</summary>
        public Task Run(Action action, CancellationToken token = default(CancellationToken))
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
        }
        public Task<TResult> Run<TResult>(Func<TResult> action, CancellationToken token = default(CancellationToken))
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
        }
        public Task Run(Func<Task> action, CancellationToken token = default(CancellationToken))
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
        }
        public Task<TResult> Run<TResult>(Func<Task<TResult>> action, CancellationToken token = default(CancellationToken))
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
        }
    }
