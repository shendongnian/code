 cs
public override void Initialize(AnalysisContext context)
{
    context.RegisterSyntaxNodeAction(SyntaxNodeAnalyze, SyntaxKind.InvocationExpression);
}
In this method, we registered `SyntaxNodeAnalyze` method to get callbacks from the analyzer. Inside this method, by using the 'SyntaxNodeAnalysisContext' we can query information about the `semantic objects`. In the following sample, I used `SemanticModel` to be able to enumerate the custom attributes that I was declared and now, I used them above the method declaration.
 cs
private static void SyntaxNodeAnalyze(SyntaxNodeAnalysisContext context)
{
    SemanticModel semanticModel = context.SemanticModel;
    InvocationExpressionSyntax method = (InvocationExpressionSyntax)context.Node;
    var info = semanticModel.GetSymbolInfo(method).Symbol;
    if (info == null)
         return new List<AttributeData>();
    var attribs = info.GetAttributes().Where(f => f.AttributeClass.MetadataName.Equals(typeof(ThrowsExceptionAttribute).Name));
                
    foreach (var attrib in attribs)
    {
        ...
    }            
}
As you can see in the above code, we can gather useful information by using the `GetSymbolInfo` method of the 'SemanticModel'. You can use this method to get information about *Methods*, *Properties* and other semantic objects.
