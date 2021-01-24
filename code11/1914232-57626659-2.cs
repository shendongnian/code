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
					WindowsFormsSynchronizationContext.AutoInstall = false; // it's ThreadStatic
					using (var winformsSyncContext = new WindowsFormsSynchronizationContext())
					{
						SynchronizationContext.SetSynchronizationContext(winformsSyncContext);
						try
						{
							schedulerTcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
							Application.Run(createForm());
						}
						finally
						{
							SynchronizationContext.SetSynchronizationContext(null);
						}
						threadEndTcs.TrySetResult(true);
					}
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
				await threadEndTcs.Task.ConfigureAwait(false);
				Debug.Assert(Thread.CurrentThread != _thread);
				_thread.Join();
			}
			_thread.SetApartmentState(ApartmentState.STA);
			_thread.IsBackground = true;
			_thread.Start();
			_taskScheduler = schedulerTcs.Task.Result;
			_threadEndTask = waitForThreadEndAsync();
		}
		/// <summary>shutdown the STA thread</summary>
		public void Dispose()
		{
			if (Thread.CurrentThread == _thread)
				throw new InvalidOperationException();
			lock (_lock)
			{
				if (!_threadEndTask.IsCompleted)
				{
					// execute Application.ExitThread() on the STA thread
					Run(() => Application.ExitThread());
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
