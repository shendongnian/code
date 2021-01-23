    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "(?<=\").*(?=\")";
            string str =
            "text1.text2 = text3[\"THISISWHATIWANTTOCAPTURE\"].text4();";
    
            Match match = Regex.Match(str, pattern);
    
            foreach (var c in match.Captures)
            {
                Console.WriteLine(c);
            }
        }
    }
