    #define aws
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
    #if docker
            Console.WriteLine("Build for docker.");
    #endif
    #if aws
            Console.WriteLine("Build for aws.");
    #endif
        }
    }
