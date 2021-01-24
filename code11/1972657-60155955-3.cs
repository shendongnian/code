csharp
public Task<int> MyFunc1()
{
	SomeObj someObj = new SomeObj();
	TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
	someObj.OnAsynComplete += (r) => tcs.SetResult(r);
	someObj.GetSomeObj();
	return tcs.Task;
}
Or you could do something with an extension:
csharp
public static class SomeObjExtension
{
	public static Task<int> GetResultAsyncTask(this SomeObj someObj)
	{
		TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
		someObj.OnAsynComplete += (r) => tcs.SetResult(r);
		someObj.GetSomeObj();
		return tcs.Task;
	}
}
async void Main()
{
	SomeObj someObj = new SomeObj();
	int result = await someObj.GetResultAsyncTask();
	Console.WriteLine($"Got some number back: {result}");
}
If you were to run it without the extension, it follows the pattern you specified:
csharp
void Main()
{
	SomeObj someObj = new SomeObj();
	someObj.OnAsynComplete += (r) => Console.WriteLine($"Got some number back: {r}");
	someObj.GetSomeObj();
}
For testing, I created `SomeObj` like this:
csharp
public class SomeObj
{
	public void GetSomeObj()
	{
		Task.Run(async () => 
		{
			//do something...
			await Task.Delay(5000);
			OnAsynComplete?.Invoke(new Random().Next(1, 10000));
		});
	}
	public event OnAsyncCompleteHandler OnAsynComplete;
	public delegate void OnAsyncCompleteHandler(int result);
}
