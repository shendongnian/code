       Console.WriteLine("Geef een getal: ");
       int invoer = int.Parse(Console.ReadLine());
       int som = 0;
       int i=1;
    while (invoer != 0)
    {
        Console.WriteLine("Geef een getal: ");
        invoer = int.Parse(Console.ReadLine());
        if (i % 5 == 0)
        {
            som += i;
        }
        
        Console.WriteLine($"De some van de 5e, 10e, 15e.....is: {som}");
       i++;
    }
