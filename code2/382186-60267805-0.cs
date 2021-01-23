using System;
class Solution
{
    static string timeConversion(string s)
    {
        return DateTime.Parse(s).ToString("HH:mm");
    }
    static void Main(string[] args)
    {
        Console.WriteLine(timeConversion("01:00 PM"));
        Console.Read();
    }
}
