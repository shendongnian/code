    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Diagnostics;
    using System.Collections.Immutable;
	
	// ...
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Analyzer : DiagnosticAnalyzer
    {
        private static readonly string typeName =
            typeof(System.PlatformNotSupportedException).FullName;
        private static DiagnosticDescriptor Rule =
            new DiagnosticDescriptor(id: "CreatesPlatformNotSupportedException",
                                     title: "Creates 'PlatformNotSupportedException'",
                                     messageFormat: "Do not create 'PlatformNotSupportedException'",
                                     category: "Usage",
                                     defaultSeverity: DiagnosticSeverity.Error,
                                     isEnabledByDefault: true,
                                     description: "Creates 'PlatformNotSupportedException'");
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(Rule);
        public override void Initialize(AnalysisContext context) =>
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.ObjectCreationExpression);
        private void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            var type = context.SemanticModel.GetTypeInfo(context.Node).Type;
            if ($"{type.ContainingNamespace}.{type.Name}".Equals(typeName))
                context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
        }
    }
