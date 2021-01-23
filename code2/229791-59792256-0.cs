private static decimal Trim(this decimal value)
{
    var s = value.ToString(CultureInfo.InvariantCulture);
    return s.Contains(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator)
        ? Decimal.Parse(s.TrimEnd('0'), CultureInfo.InvariantCulture)
        : value;
}
private static decimal? Trim(this decimal? value)
{
    return value.HasValue ? (decimal?) value.Value.Trim() : null;
}
private static void Main(string[] args)
{
    Console.WriteLine("=>{0}", 1.0000m.Trim());
    Console.WriteLine("=>{0}", 1.000000023000m.Trim());
    Console.WriteLine("=>{0}", ((decimal?) 1.000000023000m).Trim());
    Console.WriteLine("=>{0}", ((decimal?) null).Trim());
}
Output:
=>1
=>1.000000023
=>1.000000023
=>
