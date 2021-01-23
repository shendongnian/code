    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Net;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        sealed class TaskList 
        {
            private static List<Task> tasks = new List<Task>(15);
            public static Task<T> Task<T>(Task<T> task)
            {
                lock(tasks)
                {
                    tasks.Add(task);
                }
                return task;
            }
            public static Task Task(Task result)
            {
                lock (tasks)
                {
                    tasks.Add(result);
                }
                return result; 
            }
        
            public static void WaitAll()
            {
                Console.WriteLine("Finalizing tasks...");
                lock (tasks)
                {
                    while (tasks.Exists(t => !t.IsCompleted))
                    {
                        tasks.RemoveAll(t => t.IsCompleted);
                    }
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
            
                Response();
                Console.WriteLine("done.");
                TaskList.WaitAll();
            }
            
            public async static void Response()
            {
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent:foo-agent");
                Console.WriteLine(await TaskList.Task(client.DownloadStringTaskAsync(@"http://localhost/slow/task")));            
            }
        }
    }
