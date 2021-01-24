        static void Main(string[] args)
        {
            string regex = "<input type\\=\\\"hidden\\\" name=\\\"xsrf\\.token\\\" value\\=\\\"([^\\\"]+)\\\"";
            var reg = new Regex(regex);
            string xsrfToken;
            DateTime start;
            TimeSpan diff;
            var rnd = new Random();
            for (var j = 0; j < 100; j++)
            {
                if (rnd.Next(30) < 10)
                {
                    start = DateTime.Now;
                    for (var i = 0; i < 10000000; i++)
                        xsrfToken = Regex.Match(check, regex).Groups[1].Value;
                    diff = DateTime.Now - start;
                    Console.WriteLine("RegEx: " + diff.TotalSeconds);
                    continue;
                }
                if (rnd.Next(30) < 20)
                {
                    start = DateTime.Now;
                    for (var i = 0; i < 10000000; i++)
                        xsrfToken = reg.Match(check).Groups[1].Value;
                    diff = DateTime.Now - start;
                    Console.WriteLine("RegEx Prepped: " + diff.TotalSeconds);
                    continue;
                }
                start = DateTime.Now;
                for (var i = 0; i < 10000000; i++)
                    xsrfToken = InBetween(check, "name=\"xsrf.token\" value=\"", ">");
                diff = DateTime.Now - start;
                Console.WriteLine("InBetween: " + diff.TotalSeconds);
            }
            Console.ReadKey();
        }
        public static string InBetween(string source, string start, string end)
        {
            var startPos = source.IndexOf(start, StringComparison.Ordinal);
            if (startPos < 0) return null;
            startPos += start.Length;
            var endPos = source.IndexOf(end, startPos, StringComparison.Ordinal);
            return endPos < 0 ? null : source.Substring(startPos, endPos - startPos - 1);
        }
