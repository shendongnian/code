    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"<a href=""{link:3645}"">One line</a><br/>
    <p>yada yaya</p>
    <a href=""{link:2780}"" target=""_blank"">Another link</a>";
            
            Regex regex = new Regex(@"\{([^}]*)\}");
            foreach (Match match in regex.Matches(text))
            {
                Console.WriteLine(match.Groups[1].Value);
            }
        }
    }
