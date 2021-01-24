            string content = Console.ReadLine();
            var matchResult = new Regex("(?<='Skills':).*?}]").Matches(content);
            foreach(Match match in matchResult)
            {
                string matchValueWithoutSingleQuote = match.Value.Replace("'", string.Empty);
                content = content.Replace(match.Value, matchValueWithoutSingleQute);
            }
            Console.WriteLine(content);
            Console.ReadLine();
