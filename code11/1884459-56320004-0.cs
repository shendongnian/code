    int totalWoodChucks = 0;
    int days = 0;
    const int MAXDAYS = 10;
    const int MINDAYS = 1;
    const int MAXWOOD = 100;
    const int MINWOOD = 1;
    bool validWoodChucks = false;
    while(!validWoodChucks)
    {
        Console.Write("Enter number of woodchucks for this simulation (1-100): ");
        int.TryParse(Console.ReadLine(), out totalWoodChucks);
        if(totalWoodChucks > MAXWOOD || totalWoodChucks < MINWOOD)
        {
            Console.WriteLine("Invalid woodchucks. Please try again.");
        }
        else
        {
            validWoodChucks = true;
        }
    }
    bool validDays = false;
    while(!validDays)
    {
        Console.Write("Enter number of days for this simulation (1-10): ");
        int.TryParse(Console.ReadLine(), out days);
        if (days > MAXDAYS || days < MINDAYS)
        {
            Console.WriteLine("Invalid days. Please try again.");
        }
        else
        {
            validDays = true;
        }
    }
    Console.WriteLine("Wood chucks: " + totalWoodChucks);
    Console.WriteLine("Days: " + days);
    Console.ReadLine();
