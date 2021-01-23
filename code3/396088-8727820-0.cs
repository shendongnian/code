    private static int GetNumberOfAnonymousObjectCreations(string filename)
    {
        var tree = SyntaxTree.ParseCompilationUnit(
                                 File.ReadAllText("ToParse.cs"));
        return tree.Root.DescendentNodes()
                   .Where(n => n.Kind == SyntaxKind.AnonymousObjectCreationExpression)
                   .Count();
    }
