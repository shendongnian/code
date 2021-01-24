using System;
using System.Threading;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Semaphore mutex = new Semaphore(0, 1);
            Thread t = new Thread(() => {
                Console.WriteLine("Hello from another thread");
                Console.ReadLine();
                mutex.Release();
            });
            t.Start();
            while (!mutex.WaitOne(1000))
                Console.WriteLine("Waiting " + 1 + " sec");
            Console.WriteLine("Hello from main thread");
            Console.ReadLine();
        }
    }
}
