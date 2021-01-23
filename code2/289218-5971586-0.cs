    double result;
    if (double.TryParse(someString, out result))
    {
        Console.WriteLine(result);
    }
    else
    {
        // not a valid double
    }
