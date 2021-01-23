	public class TaskProfilerProvider<T> :
		BaseProfilerProvider
	{
		Timing step;
		MiniProfiler asyncProfiler;
		public TaskProfilerProvider(Timing parentStep)
		{
			this.step = parentStep;
		}
		internal T Result { get; set; }
		public override MiniProfiler GetCurrentProfiler()
		{
			return this.asyncProfiler;
		}
		public override MiniProfiler Start(ProfileLevel level)
		{
			var result = new MiniProfiler("TaskProfilerProvider<" + typeof(T).Name + ">", level);
			this.asyncProfiler = result;
			BaseProfilerProvider.SetProfilerActive(result);
			return result;
		}
		public override void Stop(bool discardResults)
		{
			if (this.asyncProfiler == null)
			{
				return;
			}
			if (!BaseProfilerProvider.StopProfiler(this.asyncProfiler))
			{
				return;
			}
			if (discardResults)
			{
				this.asyncProfiler = null;
				return;
			}
			BaseProfilerProvider.SaveProfiler(this.asyncProfiler);
		}
		public T SaveToParent()
		{
			// Add the timings from SQL to the current step
			var asyncProfiler = this.GetCurrentProfiler();
			foreach (var sqlTiming in asyncProfiler.GetSqlTimings())
			{
				this.step.AddSqlTiming(sqlTiming);
			}
			// Clear the results, they should have been copied to the main thread.
			this.Stop(true);
			return this.Result;
		}
		public static T SaveToParent(Task<TaskProfilerProvider<T>> continuedTask)
		{
			return continuedTask.Result.SaveToParent();
		}
	}
