csharp
using System;
using System.Globalization;
using static System.FormattableString;
public class Program
{
    public static void Main()
    {
        var julianCalendar = new JulianCalendar();
        var date = new DateTime(1307, 11, 13, julianCalendar);
        
        Console.WriteLine(Invariant($"Gregorian: {date:yyyy-MM-dd}"));
        Console.WriteLine(date.DayOfWeek);
    }
}
Output:
text
Gregorian: 1307-11-21
Monday
Note the "Monday" there, not Friday - I'm not sure what Wikipedia is up to there. But it agrees with an [online Julian calendar converter](http://www.onlineconversion.com/julian_date.htm).
