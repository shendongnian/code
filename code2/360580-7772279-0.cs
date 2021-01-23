    using System;
    using System.Threading;
    
    class Test
    {
        const int Iterations = 1000000;
        
        static int counter;
        
        
        static void Main()
        {
            Thread t1 = new Thread(AddLots);
            t1.Start();
            AddLots();
            t1.Join();
            Console.WriteLine(counter);
        }
        
        static void AddLots()
        {
            for (int i = 0; i < Iterations; i++)
            {
                // Broken!
                counter++;
            }
        }
    }
