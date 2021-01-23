    static bool LessThan3DecimalPlaces(decimal dec)
    {
        decimal value = dec * 1000;
        return value == Math.Floor(value);
    }
    static void Test()
    {
        Console.WriteLine(LessThan3DecimalPlaces(1m * 0.00025m));
        Console.WriteLine(LessThan3DecimalPlaces(4000m * 0.00025m));
    }
