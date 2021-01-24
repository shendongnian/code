    while (control > 0)
    {
        Console.Clear();
        if (control == 2)
        {
            Console.Write("Add meg a minimum számot: ");
            min = int.Parse(Console.ReadLine());
            Console.Write("Add meg a maximum számot: ");
            max = int.Parse(Console.ReadLine());
            Console.Write("Add meg a hány számot kérsz: ");
            quantity = int.Parse(Console.ReadLine());
        }
        else if (control == 1)
            gen = new List<int>();
        if (max - min < quantity)
            Console.WriteLine($"You cannot generate {quantity} between [{min} and {max}]");
        else
        {
            while (gen.Count < quantity) 
            {
                temp = rnd.Next(min, max);
                if (!gen.Contains(temp))
                    gen.Add(temp);
            }
            gen.Sort();
            gen.ForEach(x => Console.WriteLine(x));
        }
        Console.WriteLine("\n[2] Új adatok megadása");
        Console.WriteLine("[1] Számok újragenerálása");
        Console.WriteLine("[0] Kilépés");
        control = int.Parse(Console.ReadLine());
    }
