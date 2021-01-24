    using System;
    class Program
    {
        public static void Main(string[] args){
            var buffer = "";
            while(true){
                //Only show if buffer is empty
                if(buffer.Length == 0){
                Console.WriteLine("enter key:");
                }
                var key = Console.ReadKey(false);
    
                //Only Exit if buffer is empty and Q is pressed (if Q is the first Key pressed)
                if(buffer.Length == 0 && key.Key == ConsoleKey.Q){
                    Console.WriteLine();
                    Console.WriteLine("the key was 'Q' goodbye");
                    return;
                }
                //Every time Enter is pressed, Use and Flush the buffer
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
                }
                //else will capture everything else pressed, and add it to buffer
                else{
                    buffer += key.KeyChar;
                }
            }
        }
    }
