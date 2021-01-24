    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
      public static void Main(string[] args)
      {
        string pattern = @"(^[0-9]{1,2}\.?[0-9]?\+?$)";
        // These should be true
        Console.WriteLine(Regex.IsMatch("2.5+", pattern));
        Console.WriteLine(Regex.IsMatch("2.5+", pattern));
        Console.WriteLine(Regex.IsMatch("2+", pattern));
        Console.WriteLine(Regex.IsMatch("2", pattern));
        // These should be false
        Console.WriteLine(Regex.IsMatch("2..5", pattern));
        Console.WriteLine(Regex.IsMatch("+2.", pattern));
      }
    }
