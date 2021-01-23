    using System;
    using System.Text.RegularExpressions;
     
    public class Test
    {
     
        public static void Main()
        {
            string s = @"MyTV.Show.S09E01.HDTV.XviD
                MyTV.Show.S10E02.HDTV.XviD
                MyTV.Show.901.HDTV.XviD
                MyTV.Show.1102.HDTV.XviD";
     
            Extract(s);
                    
        }
     
        private static readonly Regex rx = new Regex
            (@"(.*?)\.S?(\d{1,2})E?(\d{2})\.(.*)", RegexOptions.IgnoreCase);
     
        static void Extract(string text)
        {
            MatchCollection matches = rx.Matches(text);
     
            foreach (Match match in matches)
            {
                Console.WriteLine("Name: {0}, Season: {1}, Ep: {2}, Stuff: {3}\n",
                    match.Groups[1].ToString().Trim(), match.Groups[2], 
                    match.Groups[3], match.Groups[4].ToString().Trim());
            }
        }
     
    }
