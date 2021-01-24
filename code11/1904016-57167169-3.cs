    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Text;
    using System;
    using System.IO;
    namespace SB.Common.ContractGenerator
    {
        class SubmitAttributeAdder : CSharpSyntaxRewriter
        {
           public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)=>
                node.WithAttributeLists(
                    node.AttributeLists.Count == 0
                        ? node.AttributeLists.Add(SyntaxFactory.AttributeList()
                             .AddAttributes(SyntaxFactory.Attribute(
                                SyntaxFactory.ParseName("Submit")))
                            // Add some whitespace to keep the code neat.
                            .WithLeadingTrivia(node.GetLeadingTrivia())
                            .WithTrailingTrivia(SyntaxFactory.Whitespace(Environment.NewLine)))
                        : node.AttributeLists);
        }
        class Program
        {
            static void Main(string[] args)
            {
                // The file name to be injected as a command line parameter
                var tree = CSharpSyntaxTree.ParseText(
                    SourceText.From(File.ReadAllText("Test.cs")));
                File.WriteAllText("Test.cs",
                    new SubmitAttributeAdder().Visit(tree.GetRoot()).ToString());
            }
        }
    }
