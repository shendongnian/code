    void PrintMaand(Maanden maand)
    {
        Console.Write(maand + "\n");
    }
    void PrintMaanden()
    {
        for (int i = 1; i < 13; i++)
        {
            Console.Write($"{i} => ");
            PrintMaand((Maanden) i);
        }
    }
