    // parse it
    var doc = XElement.Parse(theHtml);
    // find the target elements
    var targets = doc.DescendantNodes()
                     .OfType<XElement>()
                     .Where(e => e.Name.Equals("span", StringComparison.OrdinalIgnoreCase)
                              && e.IsEmpty
                              && !e.HasAttributes)
                     .ToList(); // need a copy since the contents will change
    // replace them all
    foreach (var span in targets)
        span.ReplaceWith(new XElement("br"));
    // get back the html string
    theHtml = doc.ToString();
