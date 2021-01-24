    Console.WriteLine("Please enter the first Letter");
    string search = Console.ReadLine();
    Console.Clear();
    foreach(var erg in speichert)
    {
        if (erg.B_NAME.StartsWith(search, StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine("something");
        }
    }
