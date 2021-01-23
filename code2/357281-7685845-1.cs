    void Main()
    {
        for (int index = 0; index < 10; index++)
        {
            switch (index % 3)
            {
                case 0:
                    Console.WriteLine((index + 1) + ":x");
                    break;
                case 1:
                    Console.WriteLine((index + 1) + ":y");
                    break;
                case 2:
                    Console.WriteLine((index + 1) + ":z");
                    break;
            }
        }
    }
