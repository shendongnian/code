    double temp = 0;
    if (double.TryParse("123.456", out temp)
    {
        Console.WriteLine(string.Format("Parsed temp: {0}", temp);
    }
    else
    {
        Console.WriteLine("Input value was not able to be parsed.");
    }
