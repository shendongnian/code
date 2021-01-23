    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main(string[] args)
        {
            string original = @"abc%^&123$\|a,sd";
            string replaced = Regex.Replace(original, @"[^0-9$,]", "");
            Console.WriteLine(replaced); // Prints 123$,
        }
    }
