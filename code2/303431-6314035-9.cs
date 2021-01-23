    var elementsWithMissingDetals = document.XPathSelectElements("//span[@name='foo']/span[@name='bar']")
        .Where(arg => arg.Elements().Count() == 0)
        .ToList();
    foreach (var elementsWithMissingDetal in elementsWithMissingDetals)
    {
        elementsWithMissingDetal.Add(
            new XElement("span", "first detail", new XAttribute("name", "detail1")));
        elementsWithMissingDetal.Add(
            new XElement("span", "second detail", new XAttribute("name", "detail2")));
    }
    var newXml = document.ToString();
