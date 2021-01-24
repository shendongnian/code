    using System;
    class Program
    {
        public static void Main(string[] args){
            while(true){
                Console.WriteLine("enter key:");
                var key = Console.ReadKey(true);
                switch(key.Key){
                    case ConsoleKey.Q:
                        Console.WriteLine("the key was 'Q' goodbye");
                        return;
                }
            }
        }
    }
