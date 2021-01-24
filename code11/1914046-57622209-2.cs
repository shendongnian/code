public class Program
{
    static async Task Main()
    {
        var document = CreateDocument(@"..\..\..\TestClass.cs");
        var refactoredClass = await Refactor(document);
        Console.Write(await refactoredClass.GetTextAsync());
    }
    private static async Task<Document> Refactor(Document document)
    {
        var documentEditor = await DocumentEditor.CreateAsync(document);
        var syntaxRoot = await document.GetSyntaxRootAsync();
        var comments = syntaxRoot
            .DescendantTrivia()
            .Where(t => t.IsKind(SyntaxKind.SingleLineCommentTrivia))
            .ToList();
        // Identify comments which are used to target candidate code to be refactored
        var startComments = new Queue<SyntaxTrivia>(comments.Where(c => c.ToString().TrimEnd() == "// Start block"));
        var endBlock = new Queue<SyntaxTrivia>(comments.Where(c => c.ToString().TrimEnd() == "// End block"));
        // Identify class in target file
        var parentClass = syntaxRoot.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
        var blockIndex = 0;
        foreach (var startComment in startComments)
        {
            var targetMethodName = $"TestMethod_{blockIndex}";
            var endComment = endBlock.Dequeue();
            // Create invocation for method containing refactored code
            var testMethodInvocation =
                ExpressionStatement(
                        InvocationExpression(
                            IdentifierName(targetMethodName)))
                    .WithLeadingTrivia(Whitespace("\n"))
                    .WithTrailingTrivia(Whitespace("\n\n"));
            // Identify nodes between start and end comments
            var nodes = syntaxRoot.DescendantNodes(c => c.SpanStart <= startComment.Span.Start)
                .Where(n =>
                    n.Span.Start > startComment.Span.End &&
                    n.Span.End < endComment.SpanStart && n is StatementSyntax)
                .Cast<StatementSyntax>()
                .ToList();
            // Construct list of nodes to add to target method, removing starting comment
            var targetNodes = nodes.Select((node, nodeIndex) => nodeIndex == 0 ? node.WithoutLeadingTrivia() : node).ToList();
            // Remove end comment. This is leading trivial attached to the node after the nodes we have refactored
            // FIXME this is nasty and doesn't work if there are no nodes after the end comment
            var endCommentNode = syntaxRoot.DescendantNodesAndSelf().FirstOrDefault(n => n.SpanStart > nodes.Last().Span.End && n is StatementSyntax);
            if (endCommentNode != null) documentEditor.ReplaceNode(endCommentNode, endCommentNode.WithoutLeadingTrivia());
            // Create target method, containing selected nodes
            var testMethod =
                MethodDeclaration(
                        PredefinedType(
                            Token(SyntaxKind.VoidKeyword)),
                        Identifier(targetMethodName))
                    .WithModifiers(
                        TokenList(
                            Token(SyntaxKind.PublicKeyword)))
                    .WithBody(Block(targetNodes))
                    .NormalizeWhitespace()
                    .WithTrailingTrivia(Whitespace("\n\n"));
            // Add method invocation
            documentEditor.InsertBefore(nodes.Last(), testMethodInvocation);
            // Remove nodes from main method
            foreach (var node in nodes) documentEditor.RemoveNode(node);
            // Add new method to class
            documentEditor.InsertMembers(parentClass, 0, new List<SyntaxNode> { testMethod });
            blockIndex++;
        }
        return documentEditor.GetChangedDocument();
    }
    private static Document CreateDocument(string sourcePath)
    {
        var workspace = new AdhocWorkspace();
        var projectId = ProjectId.CreateNewId();
        var versionStamp = VersionStamp.Create();
        var projectInfo = ProjectInfo.Create(projectId, versionStamp, "NewProject", "Test", LanguageNames.CSharp);
        var newProject = workspace.AddProject(projectInfo);
        var source = File.ReadAllText(sourcePath);
        var sourceText = SourceText.From(source);
        return workspace.AddDocument(newProject.Id, Path.GetFileName(sourcePath), sourceText);
    }
}
I'd be interested to see if I'm making life hard for myself with any of this -- I'm sure there's more elegant ways to do what I'm trying to do.
