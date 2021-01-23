    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main() {
    var myRegex = new Regex(@"<a.*?</a>|(hotmail)");
    string s1 = @"replace this=> hotmail not that => <a href=""http://hotmail.com"">hotmail</a>";
     
    string replaced = myRegex.Replace(s1, delegate(Match m) {
    if (m.Groups[1].Value != "") return "<span something>hotmail</span>";
    else return m.Value;
    });
    Console.WriteLine("\n" + "*** Replacements ***");
    Console.WriteLine(replaced);
     
     
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
     
    } // END Main
    } // END Program
