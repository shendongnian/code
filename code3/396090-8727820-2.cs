    private static int GetNumberOfAnonymousObjectCreations(string filename)
    {
        var tree = SyntaxTree.ParseCompilationUnit(
                                 File.ReadAllText(filename));
        return tree.Root.DescendentNodes()
                   .Where(n => n.Kind == SyntaxKind.AnonymousObjectCreationExpression)
                   .Count();
    }
