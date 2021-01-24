cs
[Flags]
public enum DateFormatStringKind
{
    HasNone = 0,
    HasDate = 1 << 0,
    HasTime = 1 << 1,
    HasBoth = HasDate | HasTime
}
public static DateFormatStringKind DescribeFormatString(string s, IFormatProvider provider)
{
    DateTime d = new DateTime(2, 2, 2, 1, 1, 1, 1); // DateTime will all non-default values
    DateTime d2 = DateTime.ParseExact(d.ToString(s, provider), s, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
    DateFormatStringKind result = DateFormatStringKind.HasNone;
    if (d2.Date.Ticks != 0)
        result |= DateFormatStringKind.HasDate;
    
    if (d2.TimeOfDay != TimeSpan.Zero)
        result |= DateFormatStringKind.HasTime;
    return result;
}
cs
var culture = System.Globalization.CultureInfo.InvariantCulture;
Console.WriteLine(DescribeFormatString("dd/MM/yyyy", culture));
Console.WriteLine(DescribeFormatString("yyyy MM yyyy", culture));
Console.WriteLine(DescribeFormatString("h:mmtt", culture));
Console.WriteLine(DescribeFormatString("dd h:mmtt", culture));
Console.WriteLine(DescribeFormatString("'literal'", culture));
none
HasDate
HasDate
HasTime
HasBoth
HasNone
