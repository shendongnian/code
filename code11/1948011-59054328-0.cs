    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AsyncUsingAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "UnAwaitedTaskInUsing";
        private const string Title = "Await Async Method";
        private const string MessageFormat = "{0} should be awaited";
        private const string Description = "Detected un-awaited task in using.";
        private const string Category = "Usage";
        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeSymbol, SyntaxKind.UsingStatement);
        }
        private static void AnalyzeSymbol(SyntaxNodeAnalysisContext context)
        {
            var invocationExpression = context.Node.ChildNodes().OfType<InvocationExpressionSyntax>().FirstOrDefault();
            if(invocationExpression == null) return;
            var awaitKeyword = context.Node.ChildTokens().OfType<AwaitExpressionSyntax>().FirstOrDefault();
            if(awaitKeyword != null) return;
            var symbolInfo = context.SemanticModel.GetSymbolInfo(invocationExpression).Symbol as IMethodSymbol;
            if(symbolInfo == null) return;
            var genericType = (symbolInfo.ReturnType as INamedTypeSymbol);
            if (!genericType?.IsGenericType ?? false || genericType.Name.ToString() != "Task'1")
                return;
            var genericTypeParameter = genericType.TypeArguments.FirstOrDefault();
            if(genericTypeParameter == null)
                return;
            var disposable = context.Compilation.GetTypeByMetadataName("System.IDisposable");
            if(!disposable.Equals(genericTypeParameter) && !genericTypeParameter.Interfaces.Any(x => disposable.Equals(x)))
                return;
            var diagnostic = Diagnostic.Create(Rule, invocationExpression.GetLocation(), invocationExpression);
            context.ReportDiagnostic(diagnostic);
        }
    }
