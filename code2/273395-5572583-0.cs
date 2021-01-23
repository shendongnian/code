    static void Main(string[] args)
    {
        Console.Write("input:");
    
        char input = Console.ReadKey().KeyChar;
    
        if (char.IsDigit(input))
        {
            int couter = (int)char.GetNumericValue(input);
            Console.WriteLine();
            if (couter % 2 != 0)
                PrintDiamond(couter);
            else
                PrintHourGlass(couter);
        }
        Console.ReadLine();
    }
    
    private static void PrintDiamond(int couter)
    {
        bool moreAsterisks = true;
        for (int row = 0; row < couter; row++)
        {
            int nAsterisks = moreAsterisks ? (2 * row) + 1 : 2 * (couter - row - 1) + 1;
            int nSpaces = (couter - nAsterisks) / 2;
    
            if (row == (couter - 1) / 2)
                moreAsterisks = false;
    
            for (int i = 0; i < nSpaces; i++)
                Console.Write(" ");
            for (int i = 0; i < nAsterisks; i++)
                Console.Write("*");
            for (int i = 0; i < nSpaces; i++)
                Console.Write(" ");
            Console.WriteLine();
        }
    }
    
    private static void PrintHourGlass(int couter)
    {
        bool moreAsterisks = false;
        for (int row = 0; row < couter - 1; row++)
        {
            int nAsterisks = moreAsterisks ? couter - 2 * (couter - row - 2) : couter - (2 * row);
            int nSpaces = (couter - nAsterisks) / 2;
    
            if (row == (couter - 2) / 2)
                moreAsterisks = true;
    
            for (int i = 0; i < nSpaces; i++)
                Console.Write(" ");
            for (int i = 0; i < nAsterisks; i++)
                Console.Write("*");
            for (int i = 0; i < nSpaces; i++)
                Console.Write(" ");
            Console.WriteLine();
        }
    }
