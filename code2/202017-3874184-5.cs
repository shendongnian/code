    class Program
    {
        static event EventHandler Progress;
    
        static void Main(string[] args)
        {
            var thread = new Thread(
                () =>
                {
                    var local = GetEvent();
                    while (local == null)
                    {
                        local = GetEvent();
                    }
                });
            thread.Start();
            Thread.Sleep(1000);
            Progress += (s, a) => { Console.WriteLine("Progress"); };
            thread.Join();
            Console.WriteLine("Stopped");
            Console.ReadLine();
        }
    
        static EventHandler GetEvent()
        {
            //Thread.MemoryBarrier();
            var local = Progress;
            return local;
        }
    }
