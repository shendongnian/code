    #define pi 
    using System;
    namespace Sample
    {
        internal class Program
        {
            static void Main(string[] args)
            {
            #if (!pi)
                Console.WriteLine("i");
            #else
                Console.WriteLine("PI undefined");
            #endif
            Console.WriteLine("ok");
            Console.ReadLine();
            }
        }
    }
