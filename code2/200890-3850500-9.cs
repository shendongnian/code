    string s = Console.ReadLine();
    int x;
    if (int.TryParse(s, out x))
    {
        Console.WriteLine("You entered the valid integer {0}", x);
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
