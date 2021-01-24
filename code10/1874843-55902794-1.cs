    var lines = Regex.Split(str, @"[\r\n]+\s*")
        .Select(l => l.Trim().Split(':').Select(w => w.Trim()).ToArray());
    var sb = new StringBuilder();
    foreach (var items in lines)
    {
        if (items[0] == "~Header~")
        {
            sb.Append(items[1].StartsWith("closed", StringComparison.InvariantCultureIgnoreCase)
                ? "</Header>\r\n"
                : $"<Header Name=\"{items[1]}\">\r\n");
        }
        else
        {
            sb.Append($"<InnerText>{items[0]}</InnerText>\r\n");
        }
    }
    var xml = XDocument.Parse(sb.ToString());
