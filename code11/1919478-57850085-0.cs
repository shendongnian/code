    static void Pyramid()
    {
    
        while(true)
        {
            Console.Write("Choose a pyramid height: ");
            int n = Int32.Parse(Console.ReadLine());
    
            if (n <= 0) continue;
    
            for (int j = 0; j < n - 1 - i; j++)
            {
                Console.Write(" ");
            }
    
            for (int j = 0; j < i + 2; j++)
            {
                Console.Write("#"); 
            }
    
            Console.Write("  ");
    
            for (int j = 0; j < i + 2; j++)
            {
                Console.Write("#");
            }
    
            Console.WriteLine();
        }
    }
