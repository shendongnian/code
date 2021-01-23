    foreach (string s in doc.Descendants()
        .Where(x => x.Name.NamespaceName == "#RowsetSchema")
        .Attributes()
        .Where(x => !x.IsNamespaceDeclaration)
        .Select(x => x.Name.LocalName)
        .Distinct())
    {
        Console.WriteLine(s);
    }
