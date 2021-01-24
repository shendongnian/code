    class Program
    {
        static async Task<string> SomethingAsync(string theValue)
        {
            await Task.Yield();
            Console.WriteLine(theValue);
            // Do a CPU bound activity
            for (int i = 0; i < 1000000; i++)
                ;
            return theValue;
        }
        static void AwaitAllTasks(List<Task> tasksList)
        {
            /// Use a wait any loop to find any tasks that have completed
            /// Warning: this is O(N2) and will not scale for thousands of tasks
            Task.Run(async () =>
            {
                while (tasksList.Count > 0)
                {
                    var t = await Task.WhenAny(tasksList);
                    tasksList.Remove(t);
                    //Console.WriteLine("One of the tasks completed.  Was it Task 1 or Task 2? Task ID: {0}", t.Id);
                    Console.WriteLine("One of the tasks completed.  It was {0}", ((Task<string>)t).Result);
                }
            }
            /// Blocking on the main thread??? Is this the right way to do this?
            /// If we don't block on the main thread the application exits....
            ).Wait();
        }
        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => SomethingAsync("Task 1")));
            taskList.Add(Task.Run(() => SomethingAsync("Task 2")));
            AwaitAllTasks(taskList);
            Console.WriteLine("All tasks completed");
        }
    }
