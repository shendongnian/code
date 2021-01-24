            int textArrayPosition = 0; // Just to separate the header part and the table part
            var headersDictionary = new Dictionary<string, string>();
            List<string> arrayHeaders;
            List<List<string>> arrayData = new List<List<string>>();
            var headersFinder = new Regex(@"^(.*?) {2,}(.*)\r\n\-*? {2,}\-*\r\n(.*?)( {2,}(.*)|$)", RegexOptions.Multiline);
            foreach (Match match in headersFinder.Matches(inputText))
            {
                if (match.Groups.Count < 4)
                    continue;
                var firstHeaderName = match.Groups[1].Value;
                var secondHeaderName = match.Groups[2].Value;
                if (!string.IsNullOrWhiteSpace(firstHeaderName))
                    headersDictionary.Add(firstHeaderName, match.Groups[3].Value);
                if (!string.IsNullOrWhiteSpace(secondHeaderName))
                {
                    if (match.Groups.Count == 6)
                        headersDictionary.Add(secondHeaderName, match.Groups[5].Value);
                    else
                        headersDictionary.Add(secondHeaderName, string.Empty);
                }
                textArrayPosition = match.Index + match.Length;
            }
            Console.WriteLine("*** Document headers :");
            foreach (var entry in headersDictionary)
                Console.WriteLine($"{entry.Key} = {entry.Value}");
