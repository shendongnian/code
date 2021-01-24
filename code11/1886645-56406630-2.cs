    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp
    {
        class Program
        {
            private string TotalTime;
    
            static void Main(string[] args)
            {
                new Program().Run();
            }
    
            private void Run()
            {
                var cts = new CancellationTokenSource();
                TotalTimer("00:00:00", cts.Token);
    
                Console.ReadLine(); // waits for you to press 'Enter' to stop TotalTimer execution.
                cts.Cancel();
                Console.WriteLine("Press 'Enter' to exit the program.");
                Console.ReadLine();  // waits for you to press 'Enter' to exit the program. See, TotalTimer stopped.
            }
            // your original method modified
            async void TotalTimer(string time, CancellationToken token)
            {
                while (!token.IsCancellationRequested)
                {
                    TimeSpan timesp = DateTime.Now - DateTime.Parse(time);
                    TotalTime = timesp.Hours + " : " + timesp.Minutes + " : " + timesp.Seconds;
                    Console.WriteLine(TotalTime); // to see it's working
                    await Task.Delay(5000, token);
                }
            }
        }
    }
