var allTasks = new List<Task>();
foreach (Entity a in AAAA)
{
  // create the task 
  task = new Task(() => {
    myMethod(a);
  },  Token, TaskCreationOptions.None);
  // Add the tasks to a list
  allTasks.Add(task);
  task.Start();
}
// Wait until all tasks are completed.
Task.WaitAll(allTasks.ToArray());
