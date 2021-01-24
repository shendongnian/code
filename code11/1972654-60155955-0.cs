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
public static class SomeObjExtension
{
	public static async Task<int> GetResult(this SomeObj someObj)
	{
		TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
		someObj.OnAsynComplete += (r) => {
			tcs.SetResult(r);
		};
		someObj.GetSomeObj();
		return await tcs.Task;
	}
}
async void Main()
{
	SomeObj someObj = new SomeObj();
	int result = await someObj.GetResult();
	Console.WriteLine($"Got some number back: {result}");
}
