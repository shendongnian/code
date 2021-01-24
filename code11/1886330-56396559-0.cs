    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp2
    {
    async class Program
    {
        static bool DownloadFile (string path)
        {
            // Do something here. long running task.
            // check for cancellation -> Task.Factory.CancellationToken.IsCancellationRequested
            return true;
        }
        static async void Main(string[] args)
        {
            var paths = new[] { "Somepaths", "to the files youwant", "to download" };
            List<Task<bool>> results = new List<Task<bool>>();
            var cts = new System.Threading.CancellationTokenSource();
            
            foreach(var path in paths)
            {
                var task = new Task<bool>(_path => DownloadFile((string)_path), path, cts.Token);
                task.Start();
                results.Add(task);
            }
            // use cts.Cancel(); to cancel all associated tasks. 
            
            // Task.WhenAll() to do something when they are all done. 
            // Task.WaitAll( results.ToArray() );  // to sit and wait. 
            Console.WriteLine("Press <Enter> to quit.");
            var final = Console.ReadLine();
        }
    }
}
