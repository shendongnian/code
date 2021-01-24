public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t button_push START");
		genericMethodAsync();
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t button_push END");
	}
	public async void genericMethodAsync()
	{
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t genericMethodAsync START");
		await someOtherAsyncMethod();
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t genericMethodAsync Calling SynchronousCode2");
		SynchronousCode2();
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t genericMethodAsync END");
	}
	private void SynchronousCode2()
	{
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t\t SynchronousCode2 START");
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t\t SynchronousCode2 END");
	}
	private async Task someOtherAsyncMethod()
	{
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t\t someOtherAsyncMethod START");
		await Task.Delay(TimeSpan.FromSeconds(2));
		Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t\t someOtherAsyncMethod END");
	}
}
T1:	 button_push START
T1:		 genericMethodAsync START
T1:			 someOtherAsyncMethod START
T1:	 button_push END
T1:			 someOtherAsyncMethod END
T1:		 genericMethodAsync Calling SynchronousCode2
T1:			 SynchronousCode2 START
T1:			 SynchronousCode2 END
T1:		 genericMethodAsync END
T1:	 button_push START
T1:		 genericMethodAsync START
T1:			 someOtherAsyncMethod START
T1:	 button_push END
T1:			 someOtherAsyncMethod END
T1:		 genericMethodAsync Calling SynchronousCode2
T1:			 SynchronousCode2 START
T1:			 SynchronousCode2 END
T1:		 genericMethodAsync END
# No UI context
In a context of a console application. The result will be different. `2` may or may not be executed by the same thread. 
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
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t genericMethodAsync Calling SynchronousCode2");
    SynchronousCode2();
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t genericMethodAsync END");
}
    private void SynchronousCode2()
    {
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t\t SynchronousCode2 START");
    Console.WriteLine($"T{System.Threading.Thread.CurrentThread.ManagedThreadId}:\t\t\t SynchronousCode2 END");
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
// .NETCoreApp,Version=v3.0
T1: Main START
T1:	 button_push START
Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\3.0.0\System.Threading.Tasks.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
T1:		 genericMethodAsync START
T1:			 someOtherAsyncMethod START
T1:	 button_push END
T1: Main after button_push
T4:			 someOtherAsyncMethod END
T4:		 genericMethodAsync Calling SynchronousCode2
T4:			 SynchronousCode2 START
T4:			 SynchronousCode2 END
T4:		 genericMethodAsync END
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
