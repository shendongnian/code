    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main()  {
    string s1 = @"max,""emily,kate"",john";
    var myRegex = new Regex(@"""[^""]*""|(,)");
    string replaced = myRegex.Replace(s1, delegate(Match m) {
        if (m.Groups[1].Value == "") return m.Value;
        else return "SplitHere";
        });
    string[] splits = Regex.Split(replaced,"SplitHere");
    foreach (string split in splits) Console.WriteLine(split);
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    } // END Main
    } // END Program
