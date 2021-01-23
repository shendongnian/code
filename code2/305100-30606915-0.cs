        static void Main(string[] args)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"<([^\s^>]+)\s*[^>]*>[^<]*</(\1)>");
            Console.WriteLine(r.IsMatch("<a>One Element</a>").ToString());
            Console.WriteLine(r.IsMatch("<a href=\"http://www.google.com\">One Element</a>").ToString());
            Console.WriteLine(r.IsMatch("<a href=\"http://www.google.com\" id=\"whatever\" class=\"ui-link\">One Element</a>").ToString());
            Console.WriteLine(r.IsMatch("<a>Not An Element</b>").ToString());
            Console.WriteLine(r.IsMatch("<a>One Element</a><b>Two Element</b><c>Red Element</c><d>Blue Element</d>").ToString());
            Console.ReadLine();
        }
