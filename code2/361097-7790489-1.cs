          string modified_html =  emas(input);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(modified_html);
            string test1 = doc.DocumentNode.InnerText;
            Console.WriteLine();
            var reg = new Regex("<(.|\n)*?>", RegexOptions.IgnoreCase);
 
            Console.WriteLine(reg.Replace(modified_html , ""));
           
            Console.Read();
        }
        public static string emas(string text)
        {
            string stripped = text;
            const string MatchEmailPattern =
           @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
            Regex rx = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Find matches.
            MatchCollection matches = rx.Matches(text);
            // Report the number of matches found.
            int noOfMatches = matches.Count;
            // Report on each match.
            foreach (Match match in matches)
            {
                
                stripped = stripped.Replace("<"+ match.Value + ">" , match.Value);
            
            }
            return stripped;
        }
       static string input = " Your html goes here  ";
