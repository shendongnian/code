    using System;
    using System.Threading;
    
    class Test
    {
        private bool stop = false;
        
        static void Main()
        {
            new Test().Start();
        }
        
        void Start()
        {
            new Thread(ThreadJob).Start();
            Thread.Sleep(500);
            stop = true;
        }
        
        void ThreadJob()
        {
            int x = 0;
            while (!stop)
            {
                x++;
            }
            Console.WriteLine("Counted to {0}", x);
        }
    }
