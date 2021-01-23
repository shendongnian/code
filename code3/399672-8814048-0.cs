    using System;
    using System.Threading;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Thread thread = new Thread(() => ReadCentralOutQueue("test"));
            thread.Start();
            thread.Join();
            
        }
         
        public static void ReadCentralOutQueue(string queueName)
        {
            Console.WriteLine("I would read queue {0} here", queueName);
        }
    }
