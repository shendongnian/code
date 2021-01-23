        using System;
        using System.Threading;
        
        
        namespace ThreadSample
        {
            class Program
            {
                static Thread thread1, thread2;
                static int sum=0;
                static void Main(string[] args)
                {
                    start();
                    Console.ReadKey();
                }
                private static void Sample() { sum = sum + 1; }
                private static void Sample2() { sum = sum + 10; }
    
                private static void start() 
                {    
                    thread1 = new Thread(new ThreadStart(Sample));
                    thread2 = new Thread(new ThreadStart(Sample2));
                    thread1.Start();
                    thread2.Start();
                 // thread1.Join(); 
                 // thread2.Join();
                    Console.WriteLine(sum);
                    Console.WriteLine();
                }
           }
    }
    
