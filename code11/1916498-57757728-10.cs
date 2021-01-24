    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public partial class AmbiguityAnalysisAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "AA0001";
        private static readonly DiagnosticDescriptor Rule =
            new DiagnosticDescriptor(id: DiagnosticId,
                                     title: "Specify the attribute.",
                                     messageFormat: "Possible attribute '{0}' is ambiguous between {1}",
                                     category: "Attribute Usage",
                                     defaultSeverity: DiagnosticSeverity.Error,
                                     isEnabledByDefault: true,
                                     description: "Ambiguous attribute.");
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(Rule);
        public override void Initialize(AnalysisContext context) =>
            context.RegisterSemanticModelAction(SemanticModelAction);
        private void SemanticModelAction(SemanticModelAnalysisContext context)
        {
            var types = GetAllTypes(context.SemanticModel.Compilation).ToArray();
            var attributes = GetAllAttribute(context);
            var ambiguities = GetAmbiguities(types, attributes);
            foreach (var ambiguity in ambiguities)
                context.ReportDiagnostic(ambiguity);
        }
    }
