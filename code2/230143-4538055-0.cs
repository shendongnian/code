    namespace threads
    {
        class Program
        {
            static int cpuload = 0;
    
            static void Main(string[] args)
            {
                Thread th = new Thread(new ThreadStart(CheckCPULoad));
                th.Start();
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("load: {0}%", cpuload);
                }
                th.Abort(); // Don't ever reach this line with while (true)
            }
    
            static void CheckCPULoad()
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    cpuload++;
                }
            }
        }
    }
