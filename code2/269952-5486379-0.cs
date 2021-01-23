	public static class MyTaskExtensions
	{
		public static Task BuildChain(this Task task, IEnumerable<Action<Task>> actions)
		{
			if (actions.Count() == 0)
				return task;
			else
			{
				Task continueWith = task.ContinueWith(actions.First());
				return continueWith.BuildChain(actions.Skip(1));
			}
		}
	}
