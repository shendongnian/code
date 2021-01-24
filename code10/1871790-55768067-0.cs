C#
public async Task<ResultOrException<T>[]> WhenAllOrException<T>(IEnumerable<Task<T>> tasks)
{
	var resultOrExceptions = Task.WhenAll(
		tasks.Select(task => ...)
	);
	var delayTask = Task.Delay(2000);
	var completedTask = await Task.WhenAny(resultOrExceptions, delayTask);
	if (completedTask == delayTask)
		throw new TimeoutException();
	return await resultOrExceptions;
}
Alternatively, if you want to return an array `ResultOrException<T>`, each one faulted with a timeout, then you can do this:
C#
public async Task<ResultOrException<T>[]> WhenAllOrException<T>(IEnumerable<Task<T>> tasks)
{
	var resultOrExceptionTasks = tasks.Select(task => ...)
		.ToArray();
	var resultOrExceptions = Task.WhenAll(resultOrExceptionTasks);
	var delayTask = Task.Delay(2000);
	var completedTask = await Task.WhenAny(resultOrExceptions, delayTask);
	if (completedTask == delayTask)
		return Enumerable.Repeat(new ResultOrException<T>(new TimeoutException()), resultOrExceptionTasks.Length).ToArray();
	return await resultOrExceptions;
}
Or, if you want to return the results that made it in time, and only return timeout exceptions for those that didn't, then you want to move the `WhenAny` *inside* the `WhenAll`:
C#
public Task<ResultOrException<T>[]> WhenAllOrException<T>(IEnumerable<Task<T>> tasks)
{
	var delayTask = Task.Delay(2000);
	return Task.WhenAll(tasks.Select(WithTimeout));
	async Task<ResultOrException<T>> WithTimeout(Task<T> task)
	{
		var completedTask = await Task.WhenAny(task, delayTask);
		if (completedTask == delayTask)
			return new ResultOrException<T>(new TimeoutException());
		try
		{
			return new ResultOrException<T>(await task);
		}
		catch (Exception ex)
		{
			return new ResultOrException<T>(ex);
		}
	}
}
Side note: you should [**always** pass a `TaskScheduler` to `ContinueWith`][1]. Also, I have a [`Try` implementation][2] that may be useful.
  [1]: https://blog.stephencleary.com/2013/10/continuewith-is-dangerous-too.html
  [2]: https://github.com/StephenCleary/Try
