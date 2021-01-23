            string subjectString = @"green,""yellow,green"",white,orange,""blue,black""";
            try
            {
                Regex regexObj = new Regex(@"(?<="")\b[a-z,]+\b(?="")|[a-z]+", RegexOptions.IgnoreCase);
                Match matchResults = regexObj.Match(subjectString);
                while (matchResults.Success)
                {
                    Console.WriteLine("{0}", matchResults.Value);
                    // matched text: matchResults.Value
                    // match start: matchResults.Index
                    // match length: matchResults.Length
                    matchResults = matchResults.NextMatch();
                }
