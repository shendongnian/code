csharp
using System;
using System.Globalization;
class Test
{
    static void Main()
    {
        var dateTime = DateTime.Now;
        string formatted = dateTime.ToString(
            "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        Console.WriteLine(formatted); // 2019-11-30 09:19:43 or similar
    }
}
    
