            public static string getBetween(string source, string before, string after)
            {
                var regExp = new Regex(string.Format("{0}(?<needle>[^{0}{1}]+){1}",before,after));
                var matches = regExp.Matches(source).Cast<Match>(). //here we use LINQ to
                    OrderBy(m => m.Groups["needle"].Value.Length).  //find shortest string
                    Select(m => m.Groups["needle"].Value);          //you can use foreach loop instead
                return matches.FirstOrDefault();
            }
