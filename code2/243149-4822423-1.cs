    class Program
    {
        static bool done;
        static void Main(string[] args)
        {
            int count = 0;            
            done = false;
            while (!done)
            {
                Thread.Sleep(2000);
                count++;
                Console.WriteLine("Calculation #" + count.ToString());
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        done = true;
                    }
                }                                
            }
            Console.WriteLine();
            Console.WriteLine("end");
        }
    }
