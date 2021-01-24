    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var my_task = Program.MainAsync();
    
                my_task.Wait();
            }
    
    
            public static async Task MainAsync()
            {
                var tasks = new SortedDictionary<string, Task<Exception>>();
                for (int idx = 1; idx <= 3; idx++)
                {
                    var parameter = idx.ToString();
                    tasks.Add(parameter, Program.TaskMethod(parameter));
                }
    
                // loop indefinitely restarting task if necessary
                while (tasks.Any())
                {
                    var taskArr = tasks.Values.ToArray();
                    var finishedIdx = Task.WaitAny(taskArr, 30000);
    
                    if (0 <= finishedIdx)
                    {
                        var finishedTask = taskArr[finishedIdx];
                        var parameter = tasks.First(kvp => kvp.Value == finishedTask).Key;
                        if (finishedTask.Result != null) // exception was thrown
                        {
                            tasks[parameter] = Program.TaskMethod(parameter); // restart the task!
                        }
                        else
                        {
                            tasks.Remove(parameter);
                        }
                    }
                }
    
            }
    
            public static async Task<Exception> TaskMethod(string task_id)
            {
                try
                {
                    Console.WriteLine("Starting Task {0}", task_id);
    
                    while (true)
                    {
                        await Task.Delay(5000);
                        Console.WriteLine("Hello from task {0}", task_id);
    
                        int i = 0;
                        int b = 32 / i;
    
                    }
    
                    return null;
                }
                catch (Exception exc)
                {
                    return exc;
                }
            }
    
        }
    }
