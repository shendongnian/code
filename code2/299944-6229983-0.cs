    IObservable<string> splitXmlTokensIntoSeparateLines(string s)
    {
        // Here, you need to split tokens into separate lines (where 'token'
        // is the beginning of an Xml element). This makes it easier down
        // the line for the TakeWhile operator.
        return new[] { firstPart, secondPart, etc }.ToObservable();
    }
    bool doesTokenTerminateDocument(string s)
    {
        // Here, you should return whether the XML represents the end of one 
        // document
    }
    var xmlDocuments = stringObservable
        .SelectMany(x => splitXmlTokensIntoSeparateLines(x))
        .TakeWhile(x => doesTokenTerminateDocument(x))
        .Aggregate(new StringBuilder(), (acc, x), acc.Append(x))
        .Select(x => {
            var ret = new XDocument();
            ret.Parse(x.ToString());
            return ret;
        })
        .Repeat();
