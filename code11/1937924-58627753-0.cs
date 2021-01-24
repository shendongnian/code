using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        // This is the input string we are replacing parts from.
        string input = "    WE ARE     THE    CHAMPIONS  MY  FRIEND";
        // Use Regex.Replace to replace the pattern in the input.
        string output = Regex.Replace(input, "\w\s+", " ");
        // Write the output.
        Console.WriteLine(input);
        Console.WriteLine(output);
    }
}
