    XDocument xd = XDocument.Parse(original);
    xd.Descendants()
      .Where(e => (e.Attributes().All(a => a.IsNamespaceDeclaration || string.IsNullOrWhiteSpace(a.Value)))
                && string.IsNullOrWhiteSpace(e.Value))
      .Remove();
