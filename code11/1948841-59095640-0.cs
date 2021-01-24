    ...
    context.RegisterCodeFix(
        CodeAction.Create(
            title: regex,
            createChangedDocument:c => ReplaceRegexAsync(context.Document, declaration, c),
            equivalenceKey: regex),
        diagnostic);
    private async Task<Document> ReplaceRegexAsync(Document document, LiteralExpressionSyntax typeDecl, CancellationToken cancellationToken)
    {
        var identifierToken = typeDecl.Token;
        var updatedText = identifierToken.Text.Replace("myword", "anotherword");
        var valueText = identifierToken.ValueText.Replace("myword", "anotherword");
        var newToken = SyntaxFactory.Literal(identifierToken.LeadingTrivia, updatedText, valueText, identifierToken.TrailingTrivia);
        var sourceText = await typeDecl.SyntaxTree.GetTextAsync(cancellationToken);
        // update document by changing the source text
        return document.WithText(sourceText.WithChanges(new TextChange(identifierToken.FullSpan, newToken.ToFullString())));
    }
