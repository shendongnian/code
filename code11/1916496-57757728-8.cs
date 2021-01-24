    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AmbiguityAnalysisCodeFixProvider)), Shared]
    public class AmbiguityAnalysisCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds =>
            ImmutableArray.Create(AmbiguityAnalysisAnalyzer.DiagnosticId);
        public sealed override FixAllProvider GetFixAllProvider() =>
            WellKnownFixAllProviders.BatchFixer;
        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var diagnostic = context.Diagnostics.First();
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            var attribute =
                root
                .FindToken(diagnostic.Location.SourceSpan.Start)
                .Parent
                .AncestorsAndSelf()
                .OfType<AttributeSyntax>()
                .First();
            foreach(var suggestion in diagnostic.Properties)
            {
                var title = $"'{suggestion.Value}' to '{suggestion.Key}'";
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: title,
                        createChangedSolution: c => ReplaceAttributeAsync(context.Document, attribute, suggestion.Key, c),
                        equivalenceKey: title),
                    diagnostic);
            }
        }
        private static async Task<Solution> ReplaceAttributeAsync(Document document, AttributeSyntax oldAttribute, string suggestion, CancellationToken cancellationToken)
        {
            var name = SyntaxFactory.ParseName(suggestion);
            var newAttribute = SyntaxFactory.Attribute(name);
            var root = await document.GetSyntaxRootAsync().ConfigureAwait(false);
            root = root.ReplaceNode(oldAttribute, newAttribute);
            return document.Project.Solution.WithDocumentSyntaxRoot(document.Id, root);
        }
    }
