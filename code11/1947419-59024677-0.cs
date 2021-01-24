    using System;
    using System.Printing;
    
    class Program
    {
        static void Main(string[] args)
        {
            LocalPrintServer localPrintServer = new LocalPrintServer();
    
            foreach (PrintQueue printQueue in localPrintServer.GetPrintQueues())
            {
                Console.WriteLine($"{printQueue.FullName}  [{printQueue.QueueStatus}]");
            }
        }
    }
