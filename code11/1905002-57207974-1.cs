    private static Guest GetGuestInfo()
    {
        Console.Write("Guest Name: ");
        var name = Console.ReadLine();
        Console.Write("Nights Staying: ");
        int.TryParse(Console.ReadLine(), out int nights);
        Console.Write("Corporate Guest? (Y/N): ");
        var corporate = Console.ReadLine();
        var guest = new Guest
        {
            Name = name,
            Nights = nights
        };
        if (corporate == "Y")
            guest.CorporateGuest = true;
        else
            guest.CorporateGuest = false;
        return guest;
    }
