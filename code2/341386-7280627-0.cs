    string input = Console.ReadLine();
    double d;
    if (!Double.TryParse(input, out d))
        Console.WriteLine("Wrong input");
    double r = d * Math.Pi;
    Console.WritLine(r);
