public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Print("\t button_push START");
		genericMethodAsync();
		Print("\t button_push END");
	}
	public async void genericMethodAsync()
	{
		Print("\t\t genericMethodAsync START");
		await someOtherAsyncMethod();
		Print("\t\t genericMethodAsync calling SynchronousCode2");
		SynchronousCode2();
		Print("\t\t genericMethodAsync END");
	}
	private void SynchronousCode2()
	{
		Print("\t\t\t SynchronousCode2 START");
		Print("\t\t\t SynchronousCode2 END");
	}
	private async Task someOtherAsyncMethod()
	{
		Print("\t\t\t someOtherAsyncMethod START");
		await Task.Delay(TimeSpan.FromSeconds(2));
		Print("\t\t\t someOtherAsyncMethod END");
	}
	private static void Print(string v) =>
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}: {v}");
}
T1: 	 button_push START
T1: 		 genericMethodAsync START
T1: 			 someOtherAsyncMethod START
T1: 	 button_push END
T1: 			 someOtherAsyncMethod END
T1: 		 genericMethodAsync calling SynchronousCode2
T1: 			 SynchronousCode2 START
T1: 			 SynchronousCode2 END
T1: 		 genericMethodAsync END
# UI context, with `.ConfigureAwait`
If `ConfigureAwait(false)` is used, then `SynchronousCode2` may be called by another thread. 
await someOtherAsyncMethod().ConfigureAwait(continueOnCapturedContext: false);
Output
T1: 	 button_push START
T1: 		 genericMethodAsync START
T1: 			 someOtherAsyncMethod START
T1: 	 button_push END
T1: 			 someOtherAsyncMethod END
T9: 		 genericMethodAsync calling SynchronousCode2
T9: 			 SynchronousCode2 START
T9: 			 SynchronousCode2 END
T9: 		 genericMethodAsync END
# No UI context
In a context of a console application. The result will be different. `2` may or may not be executed by the same thread. 
public void button_push()
{
    Print("\t button_push START");
    genericMethodAsync();
    Print("\t button_push END");
}
public async void genericMethodAsync()
{
    Print("\t\t genericMethodAsync START");
    await someOtherAsyncMethod();
    Print("\t\t genericMethodAsync calling SynchronousCode2");
    SynchronousCode2();
    Print("\t\t genericMethodAsync END");
}
private void SynchronousCode2()
{
    Print("\t\t\t SynchronousCode2 START");
    Print("\t\t\t SynchronousCode2 END");
}
private async Task someOtherAsyncMethod()
{
    Print("\t\t\t someOtherAsyncMethod START");
    await Task.Delay(TimeSpan.FromSeconds(2));
    Print("\t\t\t someOtherAsyncMethod END");
}
private static void Print(string v) =>
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}: {v}");
static void Main(string[] args)
{
    Print(" Main START");
    new Program().button_push();
    Print(" Main after button_push");
    Console.ReadLine();
}
// .NETCoreApp,Version=v3.0
T1:  Main START
T1: 	 button_push START
T1: 		 genericMethodAsync START
T1: 			 someOtherAsyncMethod START
T1: 	 button_push END
T1:  Main after button_push
T4: 			 someOtherAsyncMethod END
T4: 		 genericMethodAsync calling SynchronousCode2
T4: 			 SynchronousCode2 START
T4: 			 SynchronousCode2 END
T4: 		 genericMethodAsync END
----
# Note on `async avoid`
Generally speaking `async void` should be avoided but event handlers are the exception. 
The other very important rule is not to block the UI thread. 
You could make `button_push` `async`, make `genericMethodAsync` return `Task` and make things more predictable.
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
