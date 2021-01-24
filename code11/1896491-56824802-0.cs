    long Answer = Convert.ToInt64(Console.ReadLine());
    if (Answer == (long)num01 * (long)num02)
    {
        Console.WriteLine("Well done your correct!");
    } 
    else
    {
        int responseIndex2 = numberGen.Next(1, 3);
        switch (responseIndex2) {
            case 1:
                Console.WriteLine("You noob");
                break;
            case 2:
                Console.WriteLine("Are you trying uh?!");
                break;
        }
    }
