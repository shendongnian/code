    static void Main()
    {
        var guests = new List<Guest>();
        for (int i = 0; i < 2; i++)
        {
            guests.Add(GetGuestInfo());
        }
        using (StreamWriter sw = new StreamWriter("Guests.txt"))
        {
            foreach (var guest in guests)
            {
                WriteGuestToFile(sw, guest);
            }
        }
        Console.ReadLine();
    }
