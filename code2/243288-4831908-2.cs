    public static double? MyParseDouble(this string s)
    {
        double d;
        if (double.TryParse(s, out d))
            return d;
        return null;
    }
    public static IEnumerable<double?> CumulativeSum(this IEnumerable<double?> sequence)
    {
        double? sum = 0;
        foreach(var item in sequence)
        {
            sum += item;
            yield return sum;
        }        
    }
    ...
    textBox_f.Text
        .Split(new char[]{','})
        .Select(s => s.MyParseDouble())
        .CumulativeSum()
        .ToArray();
