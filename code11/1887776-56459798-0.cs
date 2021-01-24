C#
private static Func<Task> _func;
private static TaskCompletionSource<Task> _taskSignal = new TaskCompletionSource<Task>();
private static async Task Call()
{
  _func = Pause;
  var timer = new Timer();
  timer.Interval = 10000;
  timer.Enabled = true;
  timer.AutoReset = false;
  timer.Elapsed += Timer_Elapsed;
  Console.WriteLine("job waiting");
  var task = await _taskSignal.Task; // Get the Task instance representing Pause
  await task; // Wait for Pause to finish
  Console.WriteLine("job done");
  Console.ReadKey();
}
public static async Task Pause()
{
  Console.WriteLine("Delay started");
  await Task.Delay(10000);
  Console.WriteLine("Delay ended");
}
private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
{
  Console.WriteLine("job starting");
  var task = _func(); // Start Pause running
  _taskSignal.TrySetResult(task); // Pass the Pause task back to Main
}
  [1]: https://blog.stephencleary.com/2014/05/a-tour-of-task-part-1-constructors.html
  [2]: https://blog.stephencleary.com/2014/02/synchronous-and-asynchronous-delegate.html
