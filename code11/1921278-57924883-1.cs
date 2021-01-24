csharp
using System;
using System.Globalization;
using static System.FormattableString;
public class Program
{
    public static void Main()
    {
        var julianCalendar = new JulianCalendar();
        var date = new DateTime(1307, 10, 13, julianCalendar);
        
        Console.WriteLine(Invariant($"Gregorian: {date:yyyy-MM-dd}"));
        Console.WriteLine(date.DayOfWeek);
    }
}
Output:
text
Gregorian: 1307-10-21
Friday
