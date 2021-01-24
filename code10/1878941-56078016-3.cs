cs
async Task<TResult[]> WhenSome<TResult>(int atLeast, List<Task<TResult>> tasks)
{
	List<Task<TResult>> completedTasks = new List<System.Threading.Tasks.Task<TResult>>();
	int completed = 0;
	List<Exception> exceptions = new List<Exception>();
	
	while (completed < atLeast && tasks.Any()) {
		var completedTask = await Task.WhenAny(tasks);
		tasks.Remove(completedTask);
		if (completedTask.IsCanceled)
		{
			continue;
		}
		
		if (completedTask.IsFaulted)
		{
			exceptions.Add(completedTask.Exception);
			continue;
		}
		completed++;
		completedTasks.Add(completedTask);
	}
	if (completed >= atLeast)
	{
		return completedTasks.Select(t => t.Result).ToArray();
	}
	
	throw new AggregateException(exceptions).Flatten();
}
