    namespace ConcurrentCollectionTest
    {
        using System;
        using System.Collections.Concurrent;
        using System.Threading.Tasks;
    
        internal static class Program
        {
            private static void Main(string[] args)
            {
                ConcurrentQueue<string> cq = new ConcurrentQueue<string>();
                BlockingCollection<string> bc = new BlockingCollection<string>(cq);
                bool moreItemsToAdd = true;
    
                // Consumer thread
                Task.Factory.StartNew(() =>
                {
                    while (!bc.IsCompleted)
                    {
                        string s = bc.Take();
    
                        Console.WriteLine(s);
                    }
                });
    
                // Producer thread
                Task.Factory.StartNew(() =>
                {
                    int i = 1;
    
                    while (moreItemsToAdd)
                    {
                        bc.Add("string " + i++);
                    }
    
                    bc.CompleteAdding();
                });
    
                // Main Thread
                Console.ReadLine();
                moreItemsToAdd = false;
                Console.ReadLine();
            }
        }
    }
