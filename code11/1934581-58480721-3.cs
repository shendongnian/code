using System;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    public static void Main(string[] args)
    {
        String input = "{True,True,False},{False,True,True},{False,True,True}";
        var pattern = "{(.*?)}";
        var matches = Regex.Matches(input, pattern);
        var output2 = matches
                 .Select(m => m.Groups[1].ToString())
                 .ToList();
        foreach (var o in output2) Console.WriteLine(o);
    }
}
Output
True,True,False
False,True,True
False,True,True
