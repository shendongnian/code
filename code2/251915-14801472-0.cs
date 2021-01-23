    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("enter level");
            num = Int32.Parse(Console.ReadLine());
            int count = 1;
            for (int lines = num; lines >= 1; lines--)
            {
                
                for (int spaces = lines - 1; spaces >= 1; spaces--)
                {
                    Console.Write(" ");
                    
                }
                for (int star = 1; star <= count; star++)
                {
                    Console.Write("*");
                    Console.Write(" ");
                    
                }
                count++;
                
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
