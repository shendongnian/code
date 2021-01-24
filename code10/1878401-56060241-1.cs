    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    SyntaxTree tree = CSharpSyntaxTree.ParseText(sourceCode);
    MethodDeclarationSyntax method = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>()
        .First(m => m.Identifier.ToString() == "methodName");
    method.Body.ToFullString();
