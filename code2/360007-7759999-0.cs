    public class App
    {
        static Mutex SingleInstanceMutex = new Mutex(false, "MyApp{2CA3B0BE-26B7-46d3-9CF3-234B9EFE8681}");
        public static void Main()
        {
            while(true)
            {
                if (SingleInstanceMutex.WaitOne(TimeSpan.Zero, true));
                {
                   Console.WriteLine("Only one process can be doing this at a time")
                   SingleInstanceMutex.ReleaseMutex();
                }
            
            }
        }
    }
