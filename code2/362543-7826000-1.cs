        using System; 
        using System.Linq; 
        using System.Collections.Generic; 
        using System.Text; 
        using System.Threading; 
     
        namespace QueueDoodles 
        {
        class Program
        {
            public static readonly string[] data = { "a", "b", "c", "d", "e", "f", "g", "h" };
    
            static void Main(string[] args)
            {
                var running = true;
                var rand = new Random();
                var q = new Queue<string>();
                var qEvent = new ManualResetEvent(false);
                var pollThread = new Thread(new ThreadStart(delegate()
                {
                    while (running)
                    {
                        // Queue the next value
                        var value = data[rand.Next(data.Length)];
                        q.Enqueue(value);
                        Console.WriteLine("{0} queued {1}", Thread.CurrentThread.Name, value);
    
                        // Signal waiting thread
                        qEvent.Set();
    
                        // Simulate polling
                        Thread.Sleep(rand.Next(100));
                    }
                }));
                pollThread.Name = "Poll Thread";
    
                var workerThread = new Thread(new ThreadStart(delegate()
                {
                    while (running)
                    {
                        // Wait on the queue
                        if (!qEvent.WaitOne())
                            break;
                        qEvent.Reset();
    
                        // Process the next queue item
                        var value = q.Dequeue();
                        Console.WriteLine("{0} queued {1}", Thread.CurrentThread.Name, value);
                    }
                }));
                workerThread.Name = "Worker Thread";
    
                // Start the poll thread
                pollThread.Start();
    
                // Give it some time to fill queue
                Thread.Sleep(1000);
    
                // Start the worker thread
                workerThread.Start();
    
                // Wait for keyboard input
                Console.ReadLine();
                running = false;
                qEvent.Set();
            }
        }
    }
