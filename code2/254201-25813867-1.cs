    /// <summary>
	///		Intent: runs an async/await task synchronously. Designed for use with WPF.
    ///     Normally, under WPF, if task.Wait() is executed on the GUI thread without async
    ///     in the function signature, it will hang with a threading deadlock, this class 
    ///     solves that problem.
	/// </summary>
	public static class TaskHelper
	{
		public static void MyRunTaskSynchronously(this Task task)
		{
			if (MyIfWpfDispatcherThread)
			{
				var result = Dispatcher.CurrentDispatcher.InvokeAsync(async () => { await task; });
				result.Wait();
				if (result.Status != DispatcherOperationStatus.Completed)
				{
					throw new Exception("Error E99213. Task did not run to completion.");
				}
			}
			else
			{
				task.Wait();
				if (task.Status != TaskStatus.RanToCompletion)
				{
					throw new Exception("Error E33213. Task did not run to completion.");
				}
			}
		}
		public static T MyRunTaskSynchronously<T>(this Task<T> task)
		{		
			if (MyIfWpfDispatcherThread)
			{
				T res = default(T);
				var result = Dispatcher.CurrentDispatcher.InvokeAsync(async () => { res = await task; });
				result.Wait();
				if (result.Status != DispatcherOperationStatus.Completed)
				{
					throw new Exception("Error E89213. Task did not run to completion.");
				}
				return res;
			}
			else
			{
				T res = default(T);
				var result = Task.Run(async () => res = await task);
				result.Wait();
				if (result.Status != TaskStatus.RanToCompletion)
				{
					throw new Exception("Error E12823. Task did not run to completion.");
				}
				return res;
			}
		}
		/// <summary>
		///		If the task is running on the WPF dispatcher thread.
		/// </summary>
		public static bool MyIfWpfDispatcherThread
		{
			get
			{
				return Application.Current.Dispatcher.CheckAccess();
			}
		}
	}
