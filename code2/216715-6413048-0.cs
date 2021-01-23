    using System; 
    using System.Text.RegularExpressions;
    class Test
    {
        static void Main()
        {
            string f0o = "a {background-position: 0 0 0 1;}\nb " +
                         "{BACKGROUND-POSITION: 0 0;}";
    
            var regex = new Regex(": 0 0 2 0(;})", vRegexOptions.IgnoreCase);
            string replaced = regex.Replace(foo, "XXXXXXXX");
            Compile.WriteLine(replaced);
        }
    } 
