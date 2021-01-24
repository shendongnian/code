    void PrintMaand(Maanden maand)
    {
        Console.WriteLine((int) maand + " => " + maand);
    }
    
    void PrintMaanden()
    {
        for (int i = 1; i < 13; i++)
        {
            PrintMaand((Maanden) i);
        }
    }
