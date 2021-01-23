        List<string> interfaces = new List<string>();
        using (StringReader reader = new StringReader(subjectString))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Regex regexObj = new Regex(@"fc\d+/\d+");
                Match matchResults = regexObj.Match(line);
                while (matchResults.Success)
                {
                    interfaces.Add(matchResults.Value);
                    matchResults = matchResults.NextMatch();
                } 
            }
        }
        foreach (var inter in interfaces) Console.WriteLine("{0}", inter);
