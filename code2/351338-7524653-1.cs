    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"<a href=""{link:3645}"">One line</a><br/>
    <p>yada yaya</p>
    <a href=""{link:2780}"" target=""_blank"">Another link</a>";
            
            Regex regex = new Regex(@"\{link:([^}]*)\}");
            text = regex.Replace(text, ConvertLink);
            Console.WriteLine(text);
        }
            
        private static string ConvertLink(Match match)
        {        
            // Put real logic in here :)
            string link = match.Groups[1].Value;
            return "http://converted/" + link + ".html";
        }
    }
