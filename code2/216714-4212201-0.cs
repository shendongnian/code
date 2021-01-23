    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            string foo = "a {background-position: 0 0 0 0;}\nb "
                       + "{BACKGROUND-POSITION: 0 0;}";
            var regex = new Regex(": 0 0 0 0(;|})", RegexOptions.IgnoreCase);
            string replaced = regex.Replace(foo, "XXXXXXXX");
            Console.WriteLine(replaced);
        }
    }
