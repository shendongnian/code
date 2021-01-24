    using System;
    class Program
    {
        public static void Main(string[] args){
            var complete = true;
            var buffer = "";
            while(true){
                if(complete){
                Console.WriteLine("enter key:");
                }
                var key = Console.ReadKey(false);
    
                if(buffer.Length == 0 && key.Key == ConsoleKey.Q){
                    Console.WriteLine();
                    Console.WriteLine("the key was 'Q' goodbye");
                    return;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    if(buffer.Length > 0){
                        Console.WriteLine();
                        Console.WriteLine("buffer have {0}", buffer);
                        if(int.TryParse(buffer, out int number)){
                            Console.WriteLine("{0} is a number!", number);
                        }
                    }
                    buffer = "";
                    complete = true;
                }
                else{
                    buffer += key.KeyChar;
                    complete = false;
                }
            }
        }
    }
