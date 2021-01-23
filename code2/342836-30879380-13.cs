    xd.Descendants().Attributes().Where(a => string.IsNullOrWhiteSpace(a.Value)).Remove();
    xd.Descendants()
      .Where(e => (e.Attributes().All(a => a.IsNamespaceDeclaration))
                && string.IsNullOrWhiteSpace(e.Value))
      .Remove();
