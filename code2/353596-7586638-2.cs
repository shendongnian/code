    using System.Collections.Generic;
    using System.Threading;
    
    class Program
    {
        const int Iterations = 1000000;
        static readonly Random rng = new Random();
        
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0;  i < 8; i++)
            {
                Thread t = new Thread(ExerciseRandom);
                threads.Add(t);
                t.Start();
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            Console.WriteLine(rng.Next());
            Console.WriteLine(rng.Next());
            Console.WriteLine(rng.Next());
        }
        
        static void ExerciseRandom()
        {
            for (int i = 0; i < Iterations; i++)
            {
                rng.Next();
            }
        }
    }
