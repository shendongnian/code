    static void Main(string[] args)
    {
        double val1 = 2635.215;
        Console.Out.WriteLine(GetFirstValue(val1));     // out 2635
        Console.Out.WriteLine(GetSecondValue(val1));    // out 215
        double val2 = 2;
        Console.Out.WriteLine(GetFirstValue(val2));     // out 2
        Console.Out.WriteLine(GetSecondValue(val2));    // out 0
    }
    public static int GetFirstValue(double value)
    {
        var values = value.ToString(CultureInfo.InvariantCulture).Split('.');
        return int.Parse(values[0]);
    }
    public static int GetSecondValue(double value)
    {
        var values = value.ToString(CultureInfo.InvariantCulture).Split('.');
        return values.Length > 1 ? int.Parse(values[1]) : 0;
    }
