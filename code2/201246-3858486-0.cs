    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            Tidy("Technologist - 12345");
            Tidy("No trailing stuff");
            Tidy("A-B1 - 1 - other things");
        }
        
        private static readonly Regex regex = new Regex(@"- \d+$");
        
        static void Tidy(string text)
        {
            string tidied = regex.Replace(text, "");
            Console.WriteLine("'{0}' => '{1}'", text, tidied);
        }
    }
