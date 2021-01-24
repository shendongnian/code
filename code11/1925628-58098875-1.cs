cs
[Flags]
public enum DateFormatStringKind
{
    HasDate = 1 << 0,
    HasTime = 1 << 1,
    HasBoth = HasDate | HasTime
}
public static DateFormatStringKind DescribeFormatString(string s, IFormatProvider provider)
{
    DateTime d = new DateTime(2, 1, 1, 1, 1, 1);
    DateTime d2 = DateTime.ParseExact(d.ToString(s, provider), s, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
    bool has_date = !(d2.Date.Ticks == 0);
    bool has_time = !(d2.TimeOfDay == TimeSpan.Zero);
    return
        (has_date ? DateFormatStringKind.HasDate : 0)
        |
        (has_time ? DateFormatStringKind.HasTime : 0)
    ;
}
cs
var culture = System.Globalization.CultureInfo.InvariantCulture;
Console.WriteLine(DescribeFormatString("dd/MM/yyyy", culture));
Console.WriteLine(DescribeFormatString("yyyy MM yyyy", culture));
Console.WriteLine(DescribeFormatString("h:mmtt", culture));
Console.WriteLine(DescribeFormatString("dd h:mmtt", culture));
none
HasDate
HasDate
HasTime
HasBoth
The caveat is that if you use this function on a computer where the system clock is set to the year 0001, it will incorrectly fail to detect the "date" component in the pattern in case there is one.
