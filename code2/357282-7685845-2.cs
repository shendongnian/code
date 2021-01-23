    void Main()
    {
        for (int index = 0; index < 10; index++)
        {
            if (index % 3 == 0)
                Console.WriteLine((index + 1) + ":x");
            else if (index % 3 == 1)
                Console.WriteLine((index + 1) + ":y");
            else
                Console.WriteLine((index + 1) + ":z");
        }
    }
