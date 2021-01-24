    class Program
        {
            static  void Main(string[] args)
            {
                System.Threading.Thread.CurrentThread.Name = "ThisThread";
                AnAsyncMethod();
                while (true)
                {
                    Console.WriteLine("External While loop. Current Thread: " + $"{System.Threading.Thread.CurrentThread.Name}- {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    System.Threading.Thread.Sleep(200);
    
                }
            }
    
            public static async void AnAsyncMethod()
            {
                for (int i = 0; i < 10; i++)
                {
                    FakeWork();
                    Console.WriteLine("doing fake pre-await work. Current Thread: " + $"{System.Threading.Thread.CurrentThread.Name}- {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                }
                await System.Threading.Tasks.Task.Run(FakeWork);// Task.Run(FakeWork);
                for (int i = 0; i < 10; i++)
                {
                    FakeWork();
                    Console.WriteLine("doing fake post-await work. Current Thread: " + $"{System.Threading.Thread.CurrentThread.Name}- {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                }
                Console.WriteLine("hello");
            }
    
            public static void FakeWork()
            {
                System.Threading.Thread.Sleep(100);
                 StackTrace stackTrace = new StackTrace();
            Console.WriteLine($"Caller of Fakework method is  {stackTrace.GetFrame(1).GetMethod().Name}. Current Thread: " + $"{System.Threading.Thread.CurrentThread.Name}- {System.Threading.Thread.CurrentThread.ManagedThreadId}");
   
            }
        }
