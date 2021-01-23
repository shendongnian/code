 c#
class SingleThreadTaskScheduler : TaskScheduler
{
	public Thread TaskThread { get; private set; }
	protected override void QueueTask(Task task) {
		TaskThread = new Thread(task.RunSynchronously);
		TaskThread.Start();
	}
	// ...
}
Start your task like this:
 c#
var scheduler = new SingleThreadTaskScheduler();
Task.Factory.StartNew(action, cancellationToken, TaskCreationOptions.LongRunning, scheduler);
Then abort with:
 c#
scheduler.TaskThread.Abort();
