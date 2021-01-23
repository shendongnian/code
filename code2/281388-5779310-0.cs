    static readonly Regex DataContainerRegex =
        new Regex(@"^(\d\d:\d\d:\d\d\.\d\d\d) MC: (<DataContainer>.*?</DataContainer>)",
                  RegexOptions.Singleline | RegexOptions.Multiline);
    static IEnumerable<Tuple<DateTime, XDocument>> Parse(string data)
    {
        var matches = DataContainerRegex.Matches(data);
        return from Match match in matches
               let date = DateTime.Parse(match.Groups[1].Value,
                                         CultureInfo.InvariantCulture)
               let doc = XDocument.Parse(match.Groups[2].Value)
               select Tuple.Create(date, doc);
    }
