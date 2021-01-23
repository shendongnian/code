        static void Main(string[] args)
        {
            System.Threading.ThreadPool.SetMaxThreads(5 ,5);
            for (int i = 0; i < 100; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(p => { Console.WriteLine(p.ToString()); System.Threading.Thread.Sleep(10000); }, i);
            }
                
            Console.Read();
        }
