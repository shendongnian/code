    XDocument doc = XDocument.Load("profiles.xml");
    var existingElement = doc.Root
                             .Elements()
                             .Where(x => x.Name.ToString() == Player.name)
                             .FirstOrDefault();
    if (existingElement != null)
    {
        existingElement.ReplaceWith(profile);
    }
    else
    {
        doc.Root.Add(profile);
    }
    doc.Save("profiles.xml", SaveOptions.None);
