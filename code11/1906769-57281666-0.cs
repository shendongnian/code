c#
Task.Factory.StartNew(() =>
{
    Console.WriteLine("Sleeping");
    Thread.Sleep(1000);
    Console.WriteLine("Done");
});
// Retrieve method info for internal Task[] GetScheduledTasksForDebugger()
var typeInfo = typeof(System.Threading.Tasks.TaskScheduler);
var bindingAttr = BindingFlags.NonPublic | BindingFlags.Instance;
var methodInfo = typeInfo.GetMethod("GetScheduledTasksForDebugger", bindingAttr);
Task[] tasks = (Task[])methodInfo.Invoke(System.Threading.Tasks.TaskScheduler.Current, null);
Task.WaitAll(tasks);
I think you're going to have to manage a `List<Task>` and WaitAll on that.
