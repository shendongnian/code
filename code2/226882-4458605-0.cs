    static void TestParse()
        {
            List<string> strList = new List<string>
            {
                "AD  .1234 BNM", 
                "AD  .6547 BNM", 
                "AD  .6557 BNM", 
                "AD  .6567 BNM", 
                "AD  .6577 BNM", 
                "AD  .6587 BNM", 
                "AD  .6597 BNM", 
                "AD  .6540 BNM", 
                "AD  .6541 BNM", 
                "AD  .6542 BNM"
            };
            Stopwatch stopwatch = new Stopwatch();
            string result = "";
            stopwatch.Start();
            for (int i=0; i<100000; i++)
                foreach (string str in strList)
                {
                    var match = Regex.Match(str, @"(\.\d+)");
                    if (match.Success)
                        result = match.Groups[1].Value;
                }
            stopwatch.Stop();
            Console.WriteLine("\nTotal Regex.Match time 1000000 parses: {0}", stopwatch.ElapsedMilliseconds);
            
            result = "";
            stopwatch.Reset();
            stopwatch.Start();
            Regex exp = new Regex(@"(\.\d+)", RegexOptions.IgnoreCase);
            for (int i = 0; i < 100000; i++)
                foreach (string str in strList)
                    result = exp.Matches(str)[0].Value;
            stopwatch.Stop();
            Console.WriteLine("Total Regex object time 1000000 parses: {0}", stopwatch.ElapsedMilliseconds);
            result = "";
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
                foreach (string str in strList)
                    result = str.Substring(4, 5);
            stopwatch.Stop();
            Console.WriteLine("Total string.Substring time 1000000 parses: {0}", stopwatch.ElapsedMilliseconds);
            result = "";
            stopwatch.Reset();
            stopwatch.Start();
            char[] seps = { ' ' };
            for (int i = 0; i < 100000; i++)
                foreach (string str in strList)
                    result = str.Split(seps, StringSplitOptions.RemoveEmptyEntries)[1];
            stopwatch.Stop();
            Console.WriteLine("Total string.Split time 1000000 parses: {0}", stopwatch.ElapsedMilliseconds);
        }
