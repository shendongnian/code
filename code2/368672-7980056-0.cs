    class Program
    {
        static void Main(string[] args)
        {
            ThreadExample example = new ThreadExample();
            Thread thread = new Thread(example.Run);
            Console.WriteLine("Main: Starting thread...");
            thread.Start();
            Console.WriteLine("Press a key to send a pulse");
            Console.ReadKey();
            lock (example) //locks the object we are using for synchronization
            {
                Console.WriteLine("Sending pulse...");
                Monitor.Pulse(example); //Sends a pulse to the thread
                Console.WriteLine("Pulse sent.");
            }
            thread.Join();
            Console.ReadKey();
        }
    }
    class ThreadExample
    {
        public void Run()
        {
            Console.WriteLine("Thread: Thread has started");
            lock (this) //locks the object we are using for synchronization
            {
                Monitor.Wait(this); //Waits for one pulse - thread stops running until a pulse has been sent
                Console.WriteLine("Thread: Condition has been met");
            }
        }
    }
