    static void AutoGenrateNumbers()
    {
        int temp;
        int[] lotto = new int[7];
        Random rand = new Random();
        for (int i = 0; i < 7; i++)
        {
            temp = rand.Next(1, 50);
            lotto[i]= temp;
        }
        Console.Write($"the new lotto winning numbers are: ");
        for (int i = 0; i < 6; i++)
        {
            Console.Write(lotto[i]+" ");
        }
        Console.Write($"Bonus:{lotto[6]}");
    }
