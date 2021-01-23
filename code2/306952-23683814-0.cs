    string[] things= new string[] { "105", "101", "102", "103", "90" };
    int tmpNumber;
    foreach (var thing in (things.Where(xx => int.TryParse(xx, out tmpNumber)).OrderBy(xx =>     int.Parse(xx))).Concat(things.Where(xx => !int.TryParse(xx, out tmpNumber)).OrderBy(xx => xx)))
    {
        Console.WriteLine(thing);
    }
