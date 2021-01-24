    public static void Main(string[] args)
    {
        string[,] items = new string[100, 4];
        for (int row = 0; row < items.GetLength(0); row++)
        {
            // loop through columns of current row
            string input;
            Console.WriteLine("Item Name(enter 0 to stop): ");
            input = Console.ReadLine();
            if (input == "0") break;
            items[row, 0] = input;
            Console.WriteLine("Item Price(enter 0 to stop): ");
            input = Console.ReadLine();
            if (input == "0") break;
            items[row, 1] = input;
            Console.WriteLine("Quantity(enter 0 to stop): ");
            input = Console.ReadLine();
            if (input == "0") break;
            items[row, 2] = input;
            // ...
        }
    }
