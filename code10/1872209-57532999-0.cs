    DocumentEditor ed = await DocumentEditor.CreateAsync(document, cancellationToken);
    NamespaceDeclarationSyntax nameSpace = ed.GetChangedRoot()
      .DescendantNodes()
      .FirstOrDefault(t => t.GetType() == typeof(NamespaceDeclarationSyntax)) as NamespaceDeclarationSyntax;
    
    if (nameSpace != null)
    {
      NamespaceDeclarationSyntax modifiedWithMyUsings = nameSpace.AddUsings(myUsingLists);
      ed.ReplaceNode(nameSpace, modifiedWithMyUsings);
    }
