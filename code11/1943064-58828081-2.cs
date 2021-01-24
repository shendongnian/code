public async void button_push()
{
	await genericMethodAsync();
	SynchronousCode1();
}
async Task genericMethodAsync()
{
	 await someOtherAsyncMethodAsync();
	 SynchronousCode2();
	 SyncronousCode3();
}
----
If you don't make `button_push` `async` and don't `await` the call to `genericMethodAsync` the UI thread will not be blocked but the call to `genericMethodAsync` will be a fire and forget operation and what thread `someOtherAsyncMethodAsync` may not be the same thread as the one running `button_push`. 
Let's do an experiment.
public void button_push()
{
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t button_push START");
    genericMethodAsync();
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t button_push END");
}
public async void genericMethodAsync()
{
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t genericMethodAsync START");
    await someOtherAsyncMethod();
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t genericMethodAsync END");
}
private async Task someOtherAsyncMethod()
{
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t\t someOtherAsyncMethod START");
    await Task.Delay(TimeSpan.FromSeconds(2));
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t\t someOtherAsyncMethod END");
}
static void Main(string[] args)
{
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}: Main START");
    new Program().button_push();
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}: Main after button_push");
    Console.ReadLine();
}
T1: Main START
T1:	 button_push START
T1:		 genericMethodAsync START
T1:			 someOtherAsyncMethod START
T1:	 button_push END
T1: Main after button_push
T5:			 someOtherAsyncMethod END
T5:		 genericMethodAsync END
