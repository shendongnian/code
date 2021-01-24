public class Program
{
    static async Task Main()
    {
        var document = CreateDocument("TestClass.cs");
        var refactoredClass  = await Refactor(document);
        Console.Write(await refactoredClass .GetTextAsync());
    }
    private static async Task<Document> Refactor(Document document)
    {
        var documentEditor = await DocumentEditor.CreateAsync(document);
        var syntaxRoot = await document.GetSyntaxRootAsync();
        var comments = syntaxRoot.DescendantTrivia().Where(t => t.IsKind(SyntaxKind.MultiLineCommentTrivia) || t.IsKind(SyntaxKind.SingleLineCommentTrivia))
            .ToList();
        // Identify comments which are used to target candidate code to be refactored
        // FIXME hack using single comment
        var startComment = comments.First(c => c.ToString().Contains("Start block"));
        var endComment = comments.First(c => c.ToString().Contains("End block"));
        var parentClass = syntaxRoot.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
        var testMethodInvocation =
            ExpressionStatement(
                InvocationExpression(
                    IdentifierName("TestMethod")));
        // Identify nodes between start and end comments
        var nodes = syntaxRoot.DescendantNodes()
            .Where(n => n.SpanStart > startComment.SpanStart && n.SpanStart < endComment.SpanStart && n is StatementSyntax)
            .Cast<StatementSyntax>()
            .ToList();
        // Create target method, containing selected nodes
        var testMethod =
            MethodDeclaration(
                    PredefinedType(
                        Token(SyntaxKind.VoidKeyword)),
                    Identifier("TestMethod"))
                .WithModifiers(
                    TokenList(
                        Token(SyntaxKind.PublicKeyword)))
                .WithBody(Block(nodes))
                .NormalizeWhitespace()
                .WithTrailingTrivia(Whitespace("\n\n"));
        // Add method invocation before nodes being refactored
        documentEditor.InsertBefore(nodes.Last(), testMethodInvocation);
        // Remove nodes from main method as these have been added to target method
        foreach (var node in nodes) documentEditor.RemoveNode(node);
        // Add new method to class
        documentEditor.InsertMembers(parentClass, 0, new List<SyntaxNode> { testMethod });
        return documentEditor.GetChangedDocument();
    }
    private static Document CreateDocument(string filename)
    {
        var workspace = new AdhocWorkspace();
        var projectId = ProjectId.CreateNewId();
        var versionStamp = VersionStamp.Create();
        var projectInfo = ProjectInfo.Create(projectId, versionStamp, "NewProject", "projName", LanguageNames.CSharp);
        var newProject = workspace.AddProject(projectInfo);
        var sourcePath = $@"..\..\..\{filename}";
        var source = File.ReadAllText(sourcePath);
        var sourceText = SourceText.From(source);
        return workspace.AddDocument(newProject.Id, filename, sourceText);
    }
}
I'd be interested to see if I'm making life hard for myself with any of this.
