    class Program
	{
		static void Main(string[] args)
		{
			var t1 = Task.Factory.StartNewWithContext(async () => { await DoSomething(); });
			var t2 = Task.Factory.StartNewWithContext(async () => { await DoSomething(); });
			Task.WaitAll(t1, t2);
		}
		private static async Task DoSomething()
		{
			var id1 = TaskContext.Current.Task.Id;
			Console.WriteLine(id1);
			await Task.Delay(1000);
			var id2 = TaskContext.Current.Task.Id;
			Console.WriteLine(id2);
			Console.WriteLine(id1 == id2);
		}
	}
	public static class TaskFactoryExtensions
	{
		public static Task StartNewWithContext(this TaskFactory factory, Action action)
		{
			Task task = null;
			task = new Task(() =>
			{
				Debug.Assert(TaskContext.Current == null);
				TaskContext.Current = new TaskContext(task);
				try
				{
					action();
				}
				finally
				{
					TaskContext.Current = null;
				}
			});
			task.Start();
			return task;
		}
		public static Task StartNewWithContext(this TaskFactory factory, Func<Task> action)
		{
			Task<Task> task = null;
			task = new Task<Task>(async () =>
			{
				Debug.Assert(TaskContext.Current == null);
				TaskContext.Current = new TaskContext(task);
				try
				{
					await action();
				}
				finally
				{
					TaskContext.Current = null;
				}
			});
			task.Start();
			return task.Unwrap();
		}
	}
	public sealed class TaskContext
	{
		// Use your own unique key for better performance
		private static readonly string contextKey = Guid.NewGuid().ToString();
		public TaskContext(Task task)
		{
			this.Task = task;
		}
		public Task Task { get; private set; }
		public static TaskContext Current
		{
			get { return (TaskContext)CallContext.LogicalGetData(contextKey); }
			internal set
			{
				if (value == null)
				{
					CallContext.FreeNamedDataSlot(contextKey);
				}
				else
				{
					CallContext.LogicalSetData(contextKey, value);
				}
			}
		}
	}
