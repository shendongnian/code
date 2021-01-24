cs
public enum DateFormatStringKind
{
    DateOnly,
    TimeOnly,
    Both
}
public static DateFormatStringKind DescribeFormatString(string s, IFormatProvider provider)
{
    DateTime d = new DateTime(2, 1, 1, 1, 1, 1);
    DateTime d2 = DateTime.ParseExact(d.ToString(s, provider), s, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
    bool has_date = !(d2.Date.Ticks == 0);
    bool has_time = !(d2.TimeOfDay == TimeSpan.Zero);
    if (has_date && has_time)
        return DateFormatStringKind.Both;
    else if (has_date)
        return DateFormatStringKind.DateOnly;
    else
        return DateFormatStringKind.TimeOnly;
}
cs
var culture = System.Globalization.CultureInfo.InvariantCulture;
Console.WriteLine(DescribeFormatString("dd/MM/yyyy", culture));
Console.WriteLine(DescribeFormatString("yyyy MM yyyy", culture));
Console.WriteLine(DescribeFormatString("h:mmtt", culture));
Console.WriteLine(DescribeFormatString("dd h:mmtt", culture));
none
DateOnly
DateOnly
TimeOnly
Both
The caveat is that if you use this function on a computer where the system clock is set to the year 0001, it will incorrectly fail to detect the "date" component in the pattern in case there is one.
