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
        private static readonly DiagnosticDescriptor rule =
            new DiagnosticDescriptor(id: "ThrowsPlatformNotSupportedException",
                                     title: "Throws 'PlatformNotSupportedException'",
                                     messageFormat: "Do not throw 'PlatformNotSupportedException'",
                                     category: "Usage",
                                     defaultSeverity: DiagnosticSeverity.Error,
                                     isEnabledByDefault: true,
                                     description: "Throws 'PlatformNotSupportedException'");
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(rule);
        public override void Initialize(AnalysisContext context) =>
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.ThrowStatement);
        private void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            if (context.Node.ChildNodes().SingleOrDefault() is ObjectCreationExpressionSyntax node)
            {
                var type = context.SemanticModel.GetTypeInfo(node).Type;
                if ($"{type.ContainingNamespace}.{type.Name}".Equals(typeName))
                    context.ReportDiagnostic(Diagnostic.Create(rule, context.Node.GetLocation()));
            }
        }
    }
