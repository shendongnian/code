 csharp
void Main()
{
    var start = DateTime.Parse("12/25/1995 12:00:00");
    var end = DateTime.Parse("12/25/2005 12:00:00");
    var interval = TimeSpan.FromSeconds(5d);
    var total = EnumerateDateTimeIntervals(start, end, interval).Count();
}
IEnumerable<DateTime> EnumerateDateTimeIntervals(DateTime start, DateTime end, TimeSpan interval)
{
    var current = start;
    do
    {
        yield return current;
        current = current.Add(interval);
    } while (current.CompareTo(end) <= 0);
}
