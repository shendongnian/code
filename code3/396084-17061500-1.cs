    static void Main(string[] args)
    {
        double val1 = 2635.215;
        Console.Out.WriteLine(GetFirstValue(val1));     // out 2635
        Console.Out.WriteLine(GetSecondValue(val1));    // out 215
        double val2 = 2;
        Console.Out.WriteLine(GetFirstValue(val2));     // out 2
        Console.Out.WriteLine(GetSecondValue(val2));    // out ''
        double val3 = 3.04;
        Console.Out.WriteLine(GetFirstValue(val3));     // out 3
        Console.Out.WriteLine(GetSecondValue(val3));    // out 04
    }
    public static string GetFirstValue(double value)
    {
        var values = value.ToString(CultureInfo.InvariantCulture).Split('.');
        return values[0];
    }
    public static string GetSecondValue(double value)
    {
        var values = value.ToString(CultureInfo.InvariantCulture).Split('.');
        return values.Length > 1 ? values[1] : string.Empty;
    }
